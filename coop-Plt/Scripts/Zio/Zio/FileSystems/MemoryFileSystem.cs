using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	public class MemoryFileSystem : FileSystem
	{
		private class Watcher : FileSystemWatcher
		{
			private readonly MemoryFileSystem _fileSystem;

			public Watcher(MemoryFileSystem fileSystem, UPath path)
				: base(fileSystem, path)
			{
				_fileSystem = fileSystem;
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing && !_fileSystem.IsDisposing)
				{
					_fileSystem.TryGetDispatcher()?.Remove(this);
				}
			}
		}

		private struct NodeResult
		{
			public readonly DirectoryNode? Directory;

			public readonly FileSystemNode Node;

			public readonly string? Name;

			public readonly FindNodeFlags Flags;

			public NodeResult(DirectoryNode? directory, FileSystemNode node, string? name, FindNodeFlags flags)
			{
				Directory = directory;
				Node = node;
				Name = name;
				Flags = flags;
			}
		}

		[Flags]
		private enum FindNodeFlags
		{
			CreatePathIfNotExist = 2,
			NodeCheck = 4,
			NodeShared = 8,
			NodeExclusive = 0x10,
			KeepParentNodeExclusive = 0x20,
			KeepParentNodeShared = 0x40
		}

		private abstract class FileSystemNode : FileSystemNodeReadWriteLock
		{
			protected readonly MemoryFileSystem FileSystem;

			public DirectoryNode? Parent { get; private set; }

			public string? Name { get; private set; }

			public FileAttributes Attributes { get; set; }

			public DateTime CreationTime { get; set; }

			public DateTime LastWriteTime { get; set; }

			public DateTime LastAccessTime { get; set; }

			public bool IsDisposed { get; set; }

			public bool IsReadOnly => (Attributes & FileAttributes.ReadOnly) != 0;

			protected FileSystemNode(MemoryFileSystem fileSystem, DirectoryNode? parentNode, string? name, FileSystemNode? copyNode)
			{
				FileSystem = fileSystem ?? throw new ArgumentNullException("fileSystem");
				if (parentNode != null && name != null && name.Length > 0)
				{
					parentNode.Children.Add(name, this);
					Parent = parentNode;
					Name = name;
				}
				if (copyNode != null && copyNode.Attributes != 0)
				{
					Attributes = copyNode.Attributes;
				}
				CreationTime = DateTime.Now;
				LastWriteTime = copyNode?.LastWriteTime ?? CreationTime;
				LastAccessTime = copyNode?.LastAccessTime ?? CreationTime;
			}

			public void DetachFromParent()
			{
				Parent.Children.Remove(Name);
				Parent = null;
				Name = null;
			}

			public void AttachToParent(DirectoryNode parentNode, string name)
			{
				if (parentNode == null)
				{
					throw new ArgumentNullException("parentNode");
				}
				if (string.IsNullOrEmpty(name))
				{
					throw new ArgumentNullException("name");
				}
				Parent = parentNode;
				Parent.Children.Add(name, this);
				Name = name;
			}

			public void Dispose()
			{
				IsDisposed = true;
			}

			public virtual FileSystemNode Clone(DirectoryNode? newParent, string? newName)
			{
				FileSystemNode obj = (FileSystemNode)Clone();
				obj.Parent = newParent;
				obj.Name = newName;
				return obj;
			}
		}

		private class ListFileSystemNodes : List<KeyValuePair<string, FileSystemNode>>, IDisposable
		{
			private readonly MemoryFileSystem _fs;

			public ListFileSystemNodes(MemoryFileSystem fs)
			{
				_fs = fs ?? throw new ArgumentNullException("fs");
			}

			public void Dispose()
			{
				for (int num = base.Count - 1; num >= 0; num--)
				{
					KeyValuePair<string, FileSystemNode> keyValuePair = base[num];
					_fs.ExitExclusive(keyValuePair.Value);
				}
				Clear();
			}
		}

		[DebuggerDisplay("{DebuggerDisplay(),nq}")]
		[DebuggerTypeProxy(typeof(DebuggerProxyInternal))]
		private class DirectoryNode : FileSystemNode
		{
			private sealed class DebuggerProxyInternal
			{
				private readonly DirectoryNode _directoryNode;

				[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
				public FileSystemNode[] Items => _directoryNode._children.Values.ToArray();

				public DebuggerProxyInternal(DirectoryNode directoryNode)
				{
					_directoryNode = directoryNode;
				}
			}

			internal Dictionary<string, FileSystemNode> _children;

			public Dictionary<string, FileSystemNode> Children => _children;

			public DirectoryNode(MemoryFileSystem fileSystem)
				: base(fileSystem, null, null, null)
			{
				_children = new Dictionary<string, FileSystemNode>();
				base.Attributes = FileAttributes.Directory;
			}

			public DirectoryNode(MemoryFileSystem fileSystem, DirectoryNode parent, string name)
				: base(fileSystem, parent, name, null)
			{
				_children = new Dictionary<string, FileSystemNode>();
				base.Attributes = FileAttributes.Directory;
			}

			public override FileSystemNode Clone(DirectoryNode? newParent, string? newName)
			{
				DirectoryNode directoryNode = (DirectoryNode)base.Clone(newParent, newName);
				directoryNode._children = new Dictionary<string, FileSystemNode>();
				foreach (string key in _children.Keys)
				{
					directoryNode._children[key] = _children[key].Clone(directoryNode, key);
				}
				return directoryNode;
			}

			public override string DebuggerDisplay()
			{
				if (base.Name != null)
				{
					return $"Folder: {base.Name}, Count = {_children.Count}{base.DebuggerDisplay()}";
				}
				return $"Count = {_children.Count}{base.DebuggerDisplay()}";
			}
		}

		[DebuggerDisplay("{DebuggerDisplay(),nq}")]
		private sealed class FileNode : FileSystemNode
		{
			public FileContent Content { get; private set; }

			public FileNode(MemoryFileSystem fileSystem, DirectoryNode parentNode, string? name, FileNode? copyNode)
				: base(fileSystem, parentNode, name, copyNode)
			{
				if (copyNode != null)
				{
					Content = new FileContent(this, copyNode.Content);
					return;
				}
				base.Attributes = FileAttributes.Archive;
				Content = new FileContent(this);
			}

			public override FileSystemNode Clone(DirectoryNode? newParent, string? newName)
			{
				FileNode obj = (FileNode)base.Clone(newParent, newName);
				obj.Content = new FileContent(obj, Content);
				return obj;
			}

			public override string DebuggerDisplay()
			{
				return "File: " + base.Name + ", " + Content.DebuggerDisplay() + base.DebuggerDisplay();
			}

			public void ContentChanged()
			{
				FileSystemEventDispatcher<Watcher> fileSystemEventDispatcher = FileSystem.TryGetDispatcher();
				if (fileSystemEventDispatcher != null)
				{
					UPath path = GeneratePath();
					fileSystemEventDispatcher.RaiseChange(path);
				}
			}

			private UPath GeneratePath()
			{
				StringBuilder sharedStringBuilder = UPath.GetSharedStringBuilder();
				FileSystemNode fileSystemNode = this;
				for (DirectoryNode parent = base.Parent; parent != null; parent = parent.Parent)
				{
					sharedStringBuilder.Insert(0, fileSystemNode.Name);
					sharedStringBuilder.Insert(0, '/');
					fileSystemNode = parent;
				}
				return sharedStringBuilder.ToString();
			}
		}

		private sealed class FileContent
		{
			private readonly FileNode _fileNode;

			private readonly MemoryStream _stream;

			public long Length
			{
				get
				{
					lock (this)
					{
						return _stream.Length;
					}
				}
				set
				{
					lock (this)
					{
						_stream.SetLength(value);
					}
					_fileNode.ContentChanged();
				}
			}

			public FileContent(FileNode fileNode)
			{
				_fileNode = fileNode ?? throw new ArgumentNullException("fileNode");
				_stream = new MemoryStream();
			}

			public FileContent(FileNode fileNode, FileContent copy)
			{
				_fileNode = fileNode ?? throw new ArgumentNullException("fileNode");
				long length = copy.Length;
				_stream = new MemoryStream((int)((length <= int.MaxValue) ? length : int.MaxValue));
				CopyFrom(copy);
			}

			public byte[] ToArray()
			{
				lock (this)
				{
					return _stream.ToArray();
				}
			}

			public void CopyFrom(FileContent copy)
			{
				lock (this)
				{
					long length = copy.Length;
					byte[] array = copy.ToArray();
					_stream.Position = 0L;
					_stream.Write(array, 0, array.Length);
					_stream.Position = 0L;
					_stream.SetLength(length);
				}
			}

			public int Read(long position, byte[] buffer, int offset, int count)
			{
				lock (this)
				{
					_stream.Position = position;
					return _stream.Read(buffer, offset, count);
				}
			}

			public void Write(long position, byte[] buffer, int offset, int count)
			{
				lock (this)
				{
					_stream.Position = position;
					_stream.Write(buffer, offset, count);
				}
				_fileNode.ContentChanged();
			}

			public void SetPosition(long position)
			{
				lock (this)
				{
					_stream.Position = position;
				}
			}

			public string DebuggerDisplay()
			{
				return $"Size = {_stream.Length}";
			}
		}

		private sealed class MemoryFileStream : Stream
		{
			private readonly MemoryFileSystem _fs;

			private readonly FileNode _fileNode;

			private readonly bool _canRead;

			private readonly bool _canWrite;

			private readonly bool _isExclusive;

			private int _isDisposed;

			private long _position;

			public override bool CanRead
			{
				get
				{
					if (_isDisposed == 0)
					{
						return _canRead;
					}
					return false;
				}
			}

			public override bool CanSeek => _isDisposed == 0;

			public override bool CanWrite
			{
				get
				{
					if (_isDisposed == 0)
					{
						return _canWrite;
					}
					return false;
				}
			}

			public override long Length
			{
				get
				{
					CheckNotDisposed();
					return _fileNode.Content.Length;
				}
			}

			public override long Position
			{
				get
				{
					CheckNotDisposed();
					return _position;
				}
				set
				{
					CheckNotDisposed();
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("The position cannot be negative");
					}
					_position = value;
					_fileNode.Content.SetPosition(_position);
				}
			}

			public MemoryFileStream(MemoryFileSystem fs, FileNode fileNode, bool canRead, bool canWrite, bool isExclusive)
			{
				_fs = fs ?? throw new ArgumentNullException("fs");
				_fileNode = fileNode ?? throw new ArgumentNullException("fs");
				_canWrite = canWrite;
				_canRead = canRead;
				_isExclusive = isExclusive;
				_position = 0L;
			}

			~MemoryFileStream()
			{
				Dispose(disposing: false);
			}

			protected override void Dispose(bool disposing)
			{
				if (Interlocked.Exchange(ref _isDisposed, 1) != 1)
				{
					if (_isExclusive)
					{
						_fs.ExitExclusive(_fileNode);
					}
					else
					{
						_fs.ExitShared(_fileNode);
					}
					base.Dispose(disposing);
				}
			}

			public override void Flush()
			{
				CheckNotDisposed();
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				CheckNotDisposed();
				int num = _fileNode.Content.Read(_position, buffer, offset, count);
				_position += num;
				_fileNode.LastAccessTime = DateTime.Now;
				return num;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				CheckNotDisposed();
				long num = offset;
				switch (origin)
				{
				case SeekOrigin.Current:
					num += _position;
					break;
				case SeekOrigin.End:
					num += _fileNode.Content.Length;
					break;
				}
				if (num < 0)
				{
					throw new IOException("An attempt was made to move the file pointer before the beginning of the file");
				}
				return _position = num;
			}

			public override void SetLength(long value)
			{
				CheckNotDisposed();
				_fileNode.Content.Length = value;
				DateTime now = DateTime.Now;
				_fileNode.LastAccessTime = now;
				_fileNode.LastWriteTime = now;
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				CheckNotDisposed();
				_fileNode.Content.Write(_position, buffer, offset, count);
				_position += count;
				DateTime now = DateTime.Now;
				_fileNode.LastAccessTime = now;
				_fileNode.LastWriteTime = now;
			}

			private void CheckNotDisposed()
			{
				if (_isDisposed > 0)
				{
					throw new ObjectDisposedException("Cannot access a closed file.");
				}
			}
		}

		private class FileSystemNodeReadWriteLock
		{
			private int _sharedCount;

			private FileShare? _shared;

			internal bool IsLocked => _sharedCount != 0;

			public void EnterShared(UPath context)
			{
				EnterShared(FileShare.Read, context);
			}

			protected FileSystemNodeReadWriteLock Clone()
			{
				FileSystemNodeReadWriteLock obj = (FileSystemNodeReadWriteLock)MemberwiseClone();
				obj._sharedCount = 0;
				obj._shared = null;
				return obj;
			}

			public void EnterShared(FileShare share, UPath context)
			{
				Monitor.Enter(this);
				try
				{
					while (_sharedCount < 0)
					{
						Monitor.Wait(this);
					}
					if (_shared.HasValue)
					{
						FileShare value = _shared.Value;
						if ((share & value) != share)
						{
							throw new UnauthorizedAccessException($"Cannot access shared resource path `{context}` with shared access`{share}` while current is `{value}`");
						}
					}
					else
					{
						_shared = share;
					}
					_sharedCount++;
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
			}

			public void ExitShared()
			{
				Monitor.Enter(this);
				try
				{
					_sharedCount--;
					if (_sharedCount == 0)
					{
						_shared = null;
					}
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
			}

			public void EnterExclusive()
			{
				Monitor.Enter(this);
				try
				{
					while (_sharedCount != 0)
					{
						Monitor.Wait(this);
					}
					_sharedCount = -1;
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
			}

			public bool TryEnterShared(FileShare share)
			{
				Monitor.Enter(this);
				try
				{
					if (_sharedCount < 0)
					{
						return false;
					}
					if (_shared.HasValue)
					{
						FileShare value = _shared.Value;
						if ((share & value) != share)
						{
							return false;
						}
					}
					else
					{
						_shared = share;
					}
					_sharedCount++;
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
				return true;
			}

			public bool TryEnterExclusive()
			{
				Monitor.Enter(this);
				try
				{
					if (_sharedCount != 0)
					{
						return false;
					}
					_sharedCount = -1;
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
				return true;
			}

			public void ExitExclusive()
			{
				Monitor.Enter(this);
				try
				{
					_sharedCount = 0;
					Monitor.PulseAll(this);
				}
				finally
				{
					Monitor.Exit(this);
				}
			}

			public virtual string DebuggerDisplay()
			{
				if (_sharedCount >= 0)
				{
					if (_sharedCount <= 0)
					{
						return string.Empty;
					}
					return $" (shared lock: {_sharedCount})";
				}
				return " (exclusive lock)";
			}
		}

		private sealed class DebuggerProxy
		{
			private readonly MemoryFileSystem _fs;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public FileSystemNode[] Items => _fs._rootDirectory._children.Select<KeyValuePair<string, FileSystemNode>, FileSystemNode>((KeyValuePair<string, FileSystemNode> x) => x.Value).ToArray();

			public DebuggerProxy(MemoryFileSystem fs)
			{
				_fs = fs;
			}
		}

		private readonly DirectoryNode _rootDirectory;

		private readonly FileSystemNodeReadWriteLock _globalLock;

		private readonly object _dispatcherLock;

		private FileSystemEventDispatcher<Watcher>? _dispatcher;

		public MemoryFileSystem()
		{
			_rootDirectory = new DirectoryNode(this);
			_globalLock = new FileSystemNodeReadWriteLock();
			_dispatcherLock = new object();
		}

		protected MemoryFileSystem(MemoryFileSystem copyFrom)
		{
			if (copyFrom == null)
			{
				throw new ArgumentNullException("copyFrom");
			}
			_rootDirectory = (DirectoryNode)copyFrom._rootDirectory.Clone(null, null);
			_globalLock = new FileSystemNodeReadWriteLock();
			_dispatcherLock = new object();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				TryGetDispatcher()?.Dispose();
			}
		}

		public MemoryFileSystem Clone()
		{
			EnterFileSystemExclusive();
			try
			{
				return CloneImpl();
			}
			finally
			{
				ExitFileSystemExclusive();
			}
		}

		protected virtual MemoryFileSystem CloneImpl()
		{
			return new MemoryFileSystem(this);
		}

		protected override string DebuggerDisplay()
		{
			return base.DebuggerDisplay() + " " + _rootDirectory.DebuggerDisplay();
		}

		protected override void CreateDirectoryImpl(UPath path)
		{
			EnterFileSystemShared();
			try
			{
				CreateDirectoryNode(path);
				TryGetDispatcher()?.RaiseCreated(path);
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override bool DirectoryExistsImpl(UPath path)
		{
			if (path == UPath.Root)
			{
				return true;
			}
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(path, FindNodeFlags.NodeCheck);
				try
				{
					return nodeResult.Node is DirectoryNode;
				}
				finally
				{
					ExitFindNode(nodeResult);
				}
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override void MoveDirectoryImpl(UPath srcPath, UPath destPath)
		{
			MoveFileOrDirectory(srcPath, destPath, expectDirectory: true);
		}

		protected override void DeleteDirectoryImpl(UPath path, bool isRecursive)
		{
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(path, FindNodeFlags.NodeExclusive | FindNodeFlags.KeepParentNodeExclusive);
				bool flag = false;
				try
				{
					ValidateDirectory(nodeResult.Node, path);
					if (nodeResult.Node.IsReadOnly)
					{
						throw new IOException($"Access to the path `{path}` is denied");
					}
					using (ListFileSystemNodes listFileSystemNodes = new ListFileSystemNodes(this))
					{
						TryLockExclusive(nodeResult.Node, listFileSystemNodes, isRecursive, path);
						foreach (KeyValuePair<string, FileSystemNode> item in listFileSystemNodes)
						{
							if (item.Value.IsReadOnly)
							{
								throw new UnauthorizedAccessException($"Access to path `{path}` is denied.");
							}
						}
						for (int num = listFileSystemNodes.Count - 1; num >= 0; num--)
						{
							KeyValuePair<string, FileSystemNode> keyValuePair = listFileSystemNodes[num];
							listFileSystemNodes.RemoveAt(num);
							keyValuePair.Value.DetachFromParent();
							keyValuePair.Value.Dispose();
							ExitExclusive(keyValuePair.Value);
						}
					}
					flag = true;
				}
				finally
				{
					if (flag)
					{
						nodeResult.Node.DetachFromParent();
						nodeResult.Node.Dispose();
						TryGetDispatcher()?.RaiseDeleted(path);
					}
					ExitFindNode(nodeResult);
				}
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite)
		{
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(srcPath, FindNodeFlags.NodeShared);
				try
				{
					FileSystemNode node = nodeResult.Node;
					if (node is DirectoryNode)
					{
						throw new UnauthorizedAccessException($"Cannot copy file. The path `{srcPath}` is a directory");
					}
					if (node == null)
					{
						throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
					}
					NodeResult nodeResult2 = EnterFindNode(destPath, FindNodeFlags.NodeExclusive | FindNodeFlags.KeepParentNodeExclusive);
					string name = nodeResult2.Name;
					DirectoryNode directory = nodeResult2.Directory;
					FileSystemNode node2 = nodeResult2.Node;
					try
					{
						if (directory == null)
						{
							throw FileSystemExceptionHelper.NewDirectoryNotFoundException(destPath);
						}
						if (node2 is DirectoryNode)
						{
							throw new IOException($"The target file `{destPath}` is a directory, not a file.");
						}
						if (node2 == null)
						{
							new FileNode(this, directory, name, (FileNode)node);
							TryGetDispatcher()?.RaiseCreated(destPath);
							TryGetDispatcher()?.RaiseChange(destPath);
							return;
						}
						if (overwrite)
						{
							if (node2.IsReadOnly)
							{
								throw new UnauthorizedAccessException($"Access to path `{destPath}` is denied.");
							}
							((FileNode)node2).Content.CopyFrom(((FileNode)node).Content);
							TryGetDispatcher()?.RaiseChange(destPath);
							return;
						}
						throw new IOException($"The destination file path `{destPath}` already exist and overwrite is false");
					}
					finally
					{
						if (node2 != null)
						{
							ExitExclusive(node2);
						}
						if (directory != null)
						{
							ExitExclusive(directory);
						}
					}
				}
				finally
				{
					ExitFindNode(nodeResult);
				}
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			UPath directory = srcPath.GetDirectory();
			UPath directory2 = destPath.GetDirectory();
			UPath uPath = (destBackupPath.IsNull ? default(UPath) : destBackupPath.GetDirectory());
			bool flag = directory == directory2 && (destBackupPath.IsNull || uPath == directory);
			List<KeyValuePair<UPath, int>> list = new List<KeyValuePair<UPath, int>>
			{
				new KeyValuePair<UPath, int>(srcPath, 0),
				new KeyValuePair<UPath, int>(destPath, 1)
			};
			if (!destBackupPath.IsNull)
			{
				list.Add(new KeyValuePair<UPath, int>(destBackupPath, 2));
			}
			list.Sort((KeyValuePair<UPath, int> p1, KeyValuePair<UPath, int> p2) => string.Compare(p1.Key.FullName, p2.Key.FullName, StringComparison.Ordinal));
			if (flag)
			{
				EnterFileSystemShared();
			}
			else
			{
				EnterFileSystemExclusive();
			}
			try
			{
				NodeResult[] array = new NodeResult[destBackupPath.IsNull ? 2 : 3];
				try
				{
					for (int num = 0; num < list.Count; num++)
					{
						KeyValuePair<UPath, int> keyValuePair = list[num];
						FindNodeFlags findNodeFlags = FindNodeFlags.KeepParentNodeExclusive;
						findNodeFlags = ((keyValuePair.Value == 2) ? (findNodeFlags | FindNodeFlags.NodeShared) : (findNodeFlags | FindNodeFlags.NodeExclusive));
						array[keyValuePair.Value] = EnterFindNode(keyValuePair.Key, findNodeFlags, array);
					}
					NodeResult nodeResult = array[0];
					NodeResult nodeResult2 = array[1];
					ValidateFile(nodeResult.Node, srcPath);
					ValidateFile(nodeResult2.Node, destPath);
					if (!destBackupPath.IsNull)
					{
						NodeResult nodeResult3 = array[2];
						ValidateDirectory(nodeResult3.Directory, destPath);
						if (nodeResult3.Node != null)
						{
							ValidateFile(nodeResult3.Node, destBackupPath);
							nodeResult3.Node.DetachFromParent();
							nodeResult3.Node.Dispose();
							TryGetDispatcher()?.RaiseDeleted(destBackupPath);
						}
						nodeResult2.Node.DetachFromParent();
						nodeResult2.Node.AttachToParent(nodeResult3.Directory, nodeResult3.Name);
						TryGetDispatcher()?.RaiseRenamed(destBackupPath, destPath);
					}
					else
					{
						nodeResult2.Node.DetachFromParent();
						nodeResult2.Node.Dispose();
						TryGetDispatcher()?.RaiseDeleted(destPath);
					}
					nodeResult.Node.DetachFromParent();
					nodeResult.Node.AttachToParent(nodeResult2.Directory, nodeResult2.Name);
					TryGetDispatcher()?.RaiseRenamed(destPath, srcPath);
				}
				finally
				{
					for (int num2 = array.Length - 1; num2 >= 0; num2--)
					{
						ExitFindNode(array[num2]);
					}
				}
			}
			finally
			{
				if (flag)
				{
					ExitFileSystemShared();
				}
				else
				{
					ExitFileSystemExclusive();
				}
			}
		}

		protected override long GetFileLengthImpl(UPath path)
		{
			EnterFileSystemShared();
			try
			{
				return ((FileNode)FindNodeSafe(path, expectFileOnly: true)).Content.Length;
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override bool FileExistsImpl(UPath path)
		{
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(path, FindNodeFlags.NodeCheck);
				ExitFindNode(nodeResult);
				return nodeResult.Node is FileNode;
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override void MoveFileImpl(UPath srcPath, UPath destPath)
		{
			MoveFileOrDirectory(srcPath, destPath, expectDirectory: false);
		}

		protected override void DeleteFileImpl(UPath path)
		{
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(path, FindNodeFlags.NodeExclusive | FindNodeFlags.KeepParentNodeExclusive);
				try
				{
					FileSystemNode node = nodeResult.Node;
					if (node != null)
					{
						if (node is DirectoryNode || node.IsReadOnly)
						{
							throw new UnauthorizedAccessException($"Access to path `{path}` is denied.");
						}
						node.DetachFromParent();
						node.Dispose();
						TryGetDispatcher()?.RaiseDeleted(path);
					}
				}
				finally
				{
					ExitFindNode(nodeResult);
				}
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share)
		{
			if (mode == FileMode.Append && (access & FileAccess.Read) != 0)
			{
				throw new ArgumentException("Combining FileMode: Append with FileAccess: Read is invalid.", "access");
			}
			bool canRead = (access & FileAccess.Read) != 0;
			bool flag = (access & FileAccess.Write) != 0;
			bool flag2 = share == FileShare.None;
			EnterFileSystemShared();
			DirectoryNode directoryNode = null;
			FileNode fileNode = null;
			try
			{
				NodeResult nodeResult = EnterFindNode(path, (FindNodeFlags)((flag2 ? 16 : 8) | 0x20), share);
				if (nodeResult.Directory == null)
				{
					ExitFindNode(nodeResult);
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (nodeResult.Node is DirectoryNode || (flag && nodeResult.Node != null && nodeResult.Node.IsReadOnly))
				{
					ExitFindNode(nodeResult);
					throw new UnauthorizedAccessException($"Access to the path `{path}` is denied.");
				}
				string name = nodeResult.Name;
				directoryNode = nodeResult.Directory;
				FileNode fileNode2 = (FileNode)nodeResult.Node;
				bool flag3 = false;
				bool flag4 = false;
				if (mode == FileMode.Create)
				{
					if (fileNode2 != null)
					{
						mode = FileMode.Open;
						flag3 = true;
					}
					else
					{
						mode = FileMode.CreateNew;
					}
				}
				if (mode == FileMode.OpenOrCreate)
				{
					mode = ((fileNode2 == null) ? FileMode.CreateNew : FileMode.Open);
				}
				if (mode == FileMode.Append)
				{
					if (fileNode2 != null)
					{
						mode = FileMode.Open;
						flag4 = true;
					}
					else
					{
						mode = FileMode.CreateNew;
					}
				}
				if (mode == FileMode.Truncate)
				{
					if (fileNode2 == null)
					{
						throw FileSystemExceptionHelper.NewFileNotFoundException(path);
					}
					mode = FileMode.Open;
					flag3 = true;
				}
				if (mode == FileMode.CreateNew)
				{
					if (fileNode2 != null)
					{
						fileNode = fileNode2;
						throw FileSystemExceptionHelper.NewDestinationFileExistException(path);
					}
					fileNode2 = new FileNode(this, directoryNode, name, null);
					TryGetDispatcher()?.RaiseCreated(path);
					if (flag2)
					{
						EnterExclusive(fileNode2, path);
					}
					else
					{
						EnterShared(fileNode2, path, share);
					}
				}
				else
				{
					if (fileNode2 == null)
					{
						throw FileSystemExceptionHelper.NewFileNotFoundException(path);
					}
					ExitExclusive(directoryNode);
					directoryNode = null;
				}
				MemoryFileStream memoryFileStream = new MemoryFileStream(this, fileNode2, canRead, flag, flag2);
				if (flag4)
				{
					memoryFileStream.Position = memoryFileStream.Length;
				}
				else if (flag3)
				{
					memoryFileStream.SetLength(0L);
				}
				return memoryFileStream;
			}
			finally
			{
				if (fileNode != null)
				{
					if (flag2)
					{
						ExitExclusive(fileNode);
					}
					else
					{
						ExitShared(fileNode);
					}
				}
				if (directoryNode != null)
				{
					ExitExclusive(directoryNode);
				}
				ExitFileSystemShared();
			}
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			FileSystemNode fileSystemNode = FindNodeSafe(path, expectFileOnly: false);
			FileAttributes fileAttributes = fileSystemNode.Attributes;
			if (fileSystemNode is DirectoryNode)
			{
				fileAttributes |= FileAttributes.Directory;
			}
			else if (fileAttributes == (FileAttributes)0)
			{
				fileAttributes = FileAttributes.Normal;
			}
			return fileAttributes;
		}

		protected override void SetAttributesImpl(UPath path, FileAttributes attributes)
		{
			attributes &= ~FileAttributes.Normal;
			attributes &= ~FileAttributes.Directory;
			FindNodeSafe(path, expectFileOnly: false).Attributes = attributes;
			TryGetDispatcher()?.RaiseChange(path);
		}

		protected override DateTime GetCreationTimeImpl(UPath path)
		{
			return TryFindNodeSafe(path)?.CreationTime ?? FileSystem.DefaultFileTime;
		}

		protected override void SetCreationTimeImpl(UPath path, DateTime time)
		{
			FindNodeSafe(path, expectFileOnly: false).CreationTime = time;
			TryGetDispatcher()?.RaiseChange(path);
		}

		protected override DateTime GetLastAccessTimeImpl(UPath path)
		{
			return TryFindNodeSafe(path)?.LastAccessTime ?? FileSystem.DefaultFileTime;
		}

		protected override void SetLastAccessTimeImpl(UPath path, DateTime time)
		{
			FindNodeSafe(path, expectFileOnly: false).LastAccessTime = time;
			TryGetDispatcher()?.RaiseChange(path);
		}

		protected override DateTime GetLastWriteTimeImpl(UPath path)
		{
			return TryFindNodeSafe(path)?.LastWriteTime ?? FileSystem.DefaultFileTime;
		}

		protected override void SetLastWriteTimeImpl(UPath path, DateTime time)
		{
			FindNodeSafe(path, expectFileOnly: false).LastWriteTime = time;
			TryGetDispatcher()?.RaiseChange(path);
		}

		protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			SearchPattern search = SearchPattern.Parse(ref path, ref searchPattern);
			List<UPath> foldersToProcess = new List<UPath> { path };
			SortedSet<UPath> entries = new SortedSet<UPath>(UPath.DefaultComparerIgnoreCase);
			while (foldersToProcess.Count > 0)
			{
				UPath uPath = foldersToProcess[0];
				foldersToProcess.RemoveAt(0);
				int num = 0;
				entries.Clear();
				EnterFileSystemShared();
				try
				{
					NodeResult nodeResult = EnterFindNode(uPath, FindNodeFlags.NodeShared);
					try
					{
						if (uPath == path)
						{
							ValidateDirectory(nodeResult.Node, uPath);
							goto IL_00db;
						}
						if (nodeResult.Node is DirectoryNode)
						{
							goto IL_00db;
						}
						goto end_IL_00aa;
						IL_00db:
						foreach (KeyValuePair<string, FileSystemNode> child in ((DirectoryNode)nodeResult.Node).Children)
						{
							if (!(child.Value is FileNode) || searchTarget != SearchTarget.Directory)
							{
								bool flag = search.Match(child.Key);
								bool num2 = searchOption == SearchOption.AllDirectories && child.Value is DirectoryNode;
								bool flag2 = (child.Value is FileNode && searchTarget != SearchTarget.Directory && flag) || (child.Value is DirectoryNode && searchTarget != SearchTarget.File && flag);
								UPath item = uPath / child.Key;
								if (num2)
								{
									foldersToProcess.Insert(num++, item);
								}
								if (flag2)
								{
									entries.Add(item);
								}
							}
						}
						goto IL_01fd;
						end_IL_00aa:;
					}
					finally
					{
						ExitFindNode(nodeResult);
					}
				}
				finally
				{
					ExitFileSystemShared();
				}
				continue;
				IL_01fd:
				foreach (UPath item2 in entries)
				{
					yield return item2;
				}
			}
		}

		protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
		{
			List<UPath> foldersToProcess = new List<UPath> { path };
			List<FileSystemItem> entries = new List<FileSystemItem>();
			while (foldersToProcess.Count > 0)
			{
				UPath uPath = foldersToProcess[0];
				foldersToProcess.RemoveAt(0);
				int num = 0;
				entries.Clear();
				EnterFileSystemShared();
				try
				{
					NodeResult nodeResult = EnterFindNode(uPath, FindNodeFlags.NodeShared);
					try
					{
						if (uPath == path)
						{
							ValidateDirectory(nodeResult.Node, uPath);
							goto IL_00bf;
						}
						if (nodeResult.Node is DirectoryNode)
						{
							goto IL_00bf;
						}
						goto end_IL_008e;
						IL_00bf:
						foreach (KeyValuePair<string, FileSystemNode> child in ((DirectoryNode)nodeResult.Node).Children)
						{
							FileSystemNode value = child.Value;
							bool num2 = searchOption == SearchOption.AllDirectories && child.Value is DirectoryNode;
							UPath uPath2 = uPath / child.Key;
							if (num2)
							{
								foldersToProcess.Insert(num++, uPath2);
							}
							FileSystemItem item = new FileSystemItem
							{
								FileSystem = this,
								AbsolutePath = uPath2,
								Path = uPath2,
								Attributes = value.Attributes,
								CreationTime = value.CreationTime,
								LastWriteTime = value.LastWriteTime,
								LastAccessTime = value.LastAccessTime,
								Length = ((value is FileNode fileNode) ? fileNode.Content.Length : 0)
							};
							if (searchPredicate == null || searchPredicate(ref item))
							{
								entries.Add(item);
							}
						}
						goto IL_0218;
						end_IL_008e:;
					}
					finally
					{
						ExitFindNode(nodeResult);
					}
				}
				finally
				{
					ExitFileSystemShared();
				}
				continue;
				IL_0218:
				foreach (FileSystemItem item2 in entries)
				{
					yield return item2;
				}
			}
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			Watcher watcher = new Watcher(this, path);
			GetOrCreateDispatcher().Add(watcher);
			return watcher;
		}

		protected override string ConvertPathToInternalImpl(UPath path)
		{
			return path.FullName;
		}

		protected override UPath ConvertPathFromInternalImpl(string innerPath)
		{
			return new UPath(innerPath);
		}

		private void MoveFileOrDirectory(UPath srcPath, UPath destPath, bool expectDirectory)
		{
			UPath directory = srcPath.GetDirectory();
			UPath directory2 = destPath.GetDirectory();
			bool flag = directory == directory2;
			if (!flag && expectDirectory)
			{
				UPath directory3 = destPath.GetDirectory();
				while (!directory3.IsNull)
				{
					if (directory3 == srcPath)
					{
						throw new IOException($"Cannot move the source directory `{srcPath}` to a a sub-folder of itself `{destPath}`");
					}
					directory3 = directory3.GetDirectory();
				}
			}
			bool flag2 = !flag && string.Compare(srcPath.FullName, destPath.FullName, StringComparison.Ordinal) > 0;
			if (flag)
			{
				EnterFileSystemShared();
			}
			else
			{
				EnterFileSystemExclusive();
			}
			try
			{
				NodeResult nodeResult = default(NodeResult);
				NodeResult nodeResult2 = default(NodeResult);
				try
				{
					if (flag2)
					{
						nodeResult2 = EnterFindNode(destPath, FindNodeFlags.NodeShared | FindNodeFlags.KeepParentNodeExclusive);
						nodeResult = EnterFindNode(srcPath, FindNodeFlags.NodeExclusive | FindNodeFlags.KeepParentNodeExclusive, nodeResult2);
					}
					else
					{
						nodeResult = EnterFindNode(srcPath, FindNodeFlags.NodeExclusive | FindNodeFlags.KeepParentNodeExclusive);
						nodeResult2 = EnterFindNode(destPath, FindNodeFlags.NodeShared | FindNodeFlags.KeepParentNodeExclusive, nodeResult);
					}
					if (expectDirectory)
					{
						ValidateDirectory(nodeResult.Node, srcPath);
					}
					else
					{
						ValidateFile(nodeResult.Node, srcPath);
					}
					ValidateDirectory(nodeResult2.Directory, destPath);
					AssertNoDestination(nodeResult2.Node);
					nodeResult.Node.DetachFromParent();
					nodeResult.Node.AttachToParent(nodeResult2.Directory, nodeResult2.Name);
					TryGetDispatcher()?.RaiseDeleted(srcPath);
					TryGetDispatcher()?.RaiseCreated(destPath);
				}
				finally
				{
					if (flag2)
					{
						ExitFindNode(nodeResult);
						ExitFindNode(nodeResult2);
					}
					else
					{
						ExitFindNode(nodeResult2);
						ExitFindNode(nodeResult);
					}
				}
			}
			finally
			{
				if (flag)
				{
					ExitFileSystemShared();
				}
				else
				{
					ExitFileSystemExclusive();
				}
			}
			void AssertNoDestination(FileSystemNode node)
			{
				if (expectDirectory)
				{
					if (node is FileNode || node != null)
					{
						throw FileSystemExceptionHelper.NewDestinationFileExistException(destPath);
					}
				}
				else if (node is DirectoryNode || node != null)
				{
					throw FileSystemExceptionHelper.NewDestinationDirectoryExistException(destPath);
				}
			}
		}

		private void ValidateDirectory([NotNull] FileSystemNode? node, UPath srcPath)
		{
			if (node is FileNode)
			{
				throw new IOException($"The source directory `{srcPath}` is a file");
			}
			if (node == null)
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(srcPath);
			}
		}

		private void ValidateFile([NotNull] FileSystemNode? node, UPath srcPath)
		{
			if (node == null)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
		}

		private FileSystemNode TryFindNodeSafe(UPath path)
		{
			EnterFileSystemShared();
			try
			{
				NodeResult nodeResult = EnterFindNode(path, FindNodeFlags.NodeShared);
				try
				{
					return nodeResult.Node;
				}
				finally
				{
					ExitFindNode(nodeResult);
				}
			}
			finally
			{
				ExitFileSystemShared();
			}
		}

		private FileSystemNode FindNodeSafe(UPath path, bool expectFileOnly)
		{
			FileSystemNode fileSystemNode = TryFindNodeSafe(path);
			if (fileSystemNode == null)
			{
				if (expectFileOnly)
				{
					throw FileSystemExceptionHelper.NewFileNotFoundException(path);
				}
				throw new IOException($"The file or directory `{path}` was not found");
			}
			if (fileSystemNode is DirectoryNode && expectFileOnly)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(path);
			}
			return fileSystemNode;
		}

		private void CreateDirectoryNode(UPath path)
		{
			ExitFindNode(EnterFindNode(path, FindNodeFlags.CreatePathIfNotExist | FindNodeFlags.NodeShared));
		}

		private void ExitFindNode(NodeResult nodeResult)
		{
			FindNodeFlags flags = nodeResult.Flags;
			if (nodeResult.Node != null)
			{
				if ((flags & FindNodeFlags.NodeExclusive) != 0)
				{
					ExitExclusive(nodeResult.Node);
				}
				else if ((flags & FindNodeFlags.NodeShared) != 0)
				{
					ExitShared(nodeResult.Node);
				}
			}
			if (nodeResult.Directory != null)
			{
				if ((flags & FindNodeFlags.KeepParentNodeExclusive) != 0)
				{
					ExitExclusive(nodeResult.Directory);
				}
				else if ((flags & FindNodeFlags.KeepParentNodeShared) != 0)
				{
					ExitShared(nodeResult.Directory);
				}
			}
		}

		private NodeResult EnterFindNode(UPath path, FindNodeFlags flags, params NodeResult[] existingNodes)
		{
			return EnterFindNode(path, flags, null, existingNodes);
		}

		private NodeResult EnterFindNode(UPath path, FindNodeFlags flags, FileShare? share, params NodeResult[] existingNodes)
		{
			NodeResult result = default(NodeResult);
			FileShare share2 = share ?? FileShare.Read;
			bool flag = IsNodeAlreadyLocked(_rootDirectory, existingNodes);
			if (path == UPath.Root)
			{
				if (!flag)
				{
					if ((flags & FindNodeFlags.NodeExclusive) != 0)
					{
						EnterExclusive(_rootDirectory, path);
					}
					else if ((flags & FindNodeFlags.NodeShared) != 0)
					{
						EnterShared(_rootDirectory, path, share2);
					}
				}
				else
				{
					flags &= ~(FindNodeFlags.NodeShared | FindNodeFlags.NodeExclusive);
				}
				return new NodeResult(null, _rootDirectory, null, flags);
			}
			bool isExclusive = (flags & (FindNodeFlags.CreatePathIfNotExist | FindNodeFlags.KeepParentNodeExclusive)) != 0;
			DirectoryNode directoryNode = _rootDirectory;
			List<string> list = path.Split();
			bool flag2 = false;
			if (!flag)
			{
				EnterExclusiveOrSharedDirectoryOrBlock(_rootDirectory, path, isExclusive);
				flag2 = true;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (directoryNode == null)
				{
					break;
				}
				string text = list[i];
				bool flag3 = i + 1 == list.Count;
				DirectoryNode directoryNode2 = null;
				bool flag4 = false;
				try
				{
					if (!directoryNode.Children.TryGetValue(text, out FileSystemNode value))
					{
						if ((flags & FindNodeFlags.CreatePathIfNotExist) != 0)
						{
							value = new DirectoryNode(this, directoryNode, text);
						}
					}
					else if ((flags & FindNodeFlags.CreatePathIfNotExist) != 0 && value is FileNode)
					{
						throw new IOException($"Cannot create directory `{path}` on an existing file");
					}
					if (flag3)
					{
						if (!flag2)
						{
							flags &= ~(FindNodeFlags.KeepParentNodeExclusive | FindNodeFlags.KeepParentNodeShared);
						}
						result = new NodeResult(directoryNode, value, text, flags);
						if (value != null)
						{
							if ((flags & FindNodeFlags.NodeExclusive) != 0)
							{
								EnterExclusive(value, path);
							}
							else if ((flags & FindNodeFlags.NodeShared) != 0)
							{
								EnterShared(value, path, share2);
							}
						}
						if ((flags & (FindNodeFlags.KeepParentNodeExclusive | FindNodeFlags.KeepParentNodeShared)) != 0)
						{
							directoryNode = null;
							break;
						}
					}
					else
					{
						directoryNode2 = value as DirectoryNode;
						if (directoryNode2 != null && !IsNodeAlreadyLocked(directoryNode2, existingNodes))
						{
							EnterExclusiveOrSharedDirectoryOrBlock(directoryNode2, path, isExclusive);
							flag4 = true;
						}
					}
				}
				finally
				{
					if (flag2 && directoryNode != null)
					{
						ExitExclusiveOrShared(directoryNode, isExclusive);
					}
				}
				directoryNode = directoryNode2;
				flag2 = flag4;
			}
			return result;
		}

		private static bool IsNodeAlreadyLocked(DirectoryNode directoryNode, NodeResult[] existingNodes)
		{
			for (int i = 0; i < existingNodes.Length; i++)
			{
				NodeResult nodeResult = existingNodes[i];
				if (nodeResult.Directory == directoryNode || nodeResult.Node == directoryNode)
				{
					return true;
				}
			}
			return false;
		}

		private FileSystemEventDispatcher<Watcher> GetOrCreateDispatcher()
		{
			lock (_dispatcherLock)
			{
				if (_dispatcher == null)
				{
					_dispatcher = new FileSystemEventDispatcher<Watcher>(this);
				}
				return _dispatcher;
			}
		}

		private FileSystemEventDispatcher<Watcher>? TryGetDispatcher()
		{
			lock (_dispatcherLock)
			{
				return _dispatcher;
			}
		}

		private void EnterFileSystemShared()
		{
			_globalLock.EnterShared(UPath.Root);
		}

		private void ExitFileSystemShared()
		{
			_globalLock.ExitShared();
		}

		private void EnterFileSystemExclusive()
		{
			_globalLock.EnterExclusive();
		}

		private void ExitFileSystemExclusive()
		{
			_globalLock.ExitExclusive();
		}

		private void EnterSharedDirectoryOrBlock(DirectoryNode node, UPath context)
		{
			EnterShared(node, context, block: true, FileShare.Read);
		}

		private void EnterExclusiveOrSharedDirectoryOrBlock(DirectoryNode node, UPath context, bool isExclusive)
		{
			if (isExclusive)
			{
				EnterExclusiveDirectoryOrBlock(node, context);
			}
			else
			{
				EnterSharedDirectoryOrBlock(node, context);
			}
		}

		private void EnterExclusiveDirectoryOrBlock(DirectoryNode node, UPath context)
		{
			EnterExclusive(node, context, block: true);
		}

		private void EnterExclusive(FileSystemNode node, UPath context)
		{
			EnterExclusive(node, context, node is DirectoryNode);
		}

		private void EnterShared(FileSystemNode node, UPath context, FileShare share)
		{
			EnterShared(node, context, node is DirectoryNode, share);
		}

		private void EnterShared(FileSystemNode node, UPath context, bool block, FileShare share)
		{
			if (block)
			{
				node.EnterShared(share, context);
			}
			else if (!node.TryEnterShared(share))
			{
				string arg = ((node is FileNode) ? "file" : "directory");
				throw new IOException($"The {arg} `{context}` is already used for writing by another thread.");
			}
		}

		private void ExitShared(FileSystemNode node)
		{
			node.ExitShared();
		}

		private void EnterExclusive(FileSystemNode node, UPath context, bool block)
		{
			if (block)
			{
				node.EnterExclusive();
			}
			else if (!node.TryEnterExclusive())
			{
				string arg = ((node is FileNode) ? "file" : "directory");
				throw new IOException($"The {arg} `{context}` is already locked.");
			}
		}

		private void ExitExclusiveOrShared(FileSystemNode node, bool isExclusive)
		{
			if (isExclusive)
			{
				node.ExitExclusive();
			}
			else
			{
				node.ExitShared();
			}
		}

		private void ExitExclusive(FileSystemNode node)
		{
			node.ExitExclusive();
		}

		private void TryLockExclusive(FileSystemNode node, ListFileSystemNodes locks, bool recursive, UPath context)
		{
			if (locks == null)
			{
				throw new ArgumentNullException("locks");
			}
			if (!(node is DirectoryNode directoryNode))
			{
				return;
			}
			if (recursive)
			{
				foreach (KeyValuePair<string, FileSystemNode> child in directoryNode.Children)
				{
					EnterExclusive(child.Value, context);
					UPath context2 = context / child.Key;
					locks.Add(child);
					TryLockExclusive(child.Value, locks, recursive: true, context2);
				}
				return;
			}
			if (directoryNode.Children.Count > 0)
			{
				throw new IOException($"The directory `{context}` is not empty");
			}
		}
	}
}
