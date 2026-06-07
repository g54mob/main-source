using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltimateReplay.Storage
{
	public sealed class ReplayFileTarget : ReplayTarget
	{
		private ReplayFileContext context = new ReplayFileContext();

		private List<ReplayFileTaskRequest> threadTasks = new List<ReplayFileTaskRequest>();

		private HashSet<int> processingChunkRequests = new HashSet<int>();

		private Thread streamThread;

		private bool threadRunning = true;

		private bool threadStarted;

		private int chunkIdGenerator;

		private string targetFileLocation = string.Empty;

		[SerializeField]
		[Tooltip("The directory path where all recorded files will be stored. If this value is empty then the files will be saved in the application directory")]
		private string fileDirectory = string.Empty;

		[SerializeField]
		[Tooltip("The file name to save recorded data to")]
		private string fileName = "ReplayData.replay";

		public const int chunkSize = 24;

		public const string defaultExtension = ".replay";

		[Tooltip("When true, any existing files with the same name will be overwritten. When false, a new file with an auto-incremented id will be created based on the name value")]
		public bool overwriteExistingFiles;

		[Tooltip("The amount of chunks that can be pre-fetched from the replay file so that buffering does not occur. Higher values may give smoother results but will use more memory")]
		public int chunkCacheSize = 16;

		[Header("Debug")]
		public bool logDebugMessages = true;

		public override float Duration
		{
			get
			{
				lock (context)
				{
					return context.header.duration;
				}
			}
		}

		public override int MemorySize
		{
			get
			{
				lock (context)
				{
					return context.header.memorySize;
				}
			}
		}

		public override ReplayInitialDataBuffer InitialStateBuffer
		{
			get
			{
				lock (context)
				{
					return context.initialStateBuffer;
				}
			}
		}

		public override string TargetSceneName
		{
			get
			{
				lock (context)
				{
					return context.header.sceneName;
				}
			}
		}

		public string FileOutputDirectory
		{
			get
			{
				return fileDirectory;
			}
			set
			{
				fileDirectory = value;
				RebuildFilePaths();
				context.buffer.ReleaseAllChunks();
			}
		}

		public string FileOutputName
		{
			get
			{
				return fileName;
			}
			set
			{
				fileName = value;
				RebuildFilePaths();
				context.buffer.ReleaseAllChunks();
			}
		}

		public string TargetFileLocation => targetFileLocation;

		public override void Awake()
		{
			if (Application.isPlaying)
			{
				streamThread = new Thread(StreamThreadMain);
				streamThread.IsBackground = true;
				streamThread.Name = "UltimateReplay_StreamService";
				streamThread.Start();
				RebuildFilePaths();
			}
		}

		public override void OnDestroy()
		{
			if (Application.isPlaying)
			{
				threadRunning = false;
				streamThread.Join(1500);
				if (streamThread.IsAlive)
				{
					streamThread.Abort();
				}
				Close();
			}
		}

		public void Close()
		{
			if (context.fileStream != null)
			{
				context.fileStream.Dispose();
			}
		}

		public void RebuildFilePaths()
		{
			string text = Path.GetExtension(fileName);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
			if (string.IsNullOrEmpty(text))
			{
				text = ".replay";
				fileName += ".replay";
			}
			if (!string.IsNullOrEmpty(fileDirectory) && !Directory.Exists(fileDirectory))
			{
				Directory.CreateDirectory(fileDirectory);
			}
			string path = $"{Path.Combine(fileDirectory, fileNameWithoutExtension)}{text}";
			if (!overwriteExistingFiles)
			{
				int num = 0;
				while (File.Exists(path))
				{
					path = $"{Path.Combine(fileDirectory, fileNameWithoutExtension)}{num}{text}";
					num++;
				}
			}
			targetFileLocation = path;
		}

		private ReplayFileStream OpenFileStream(ReplayFileStreamMode mode)
		{
			string text = TargetFileLocation;
			if (File.Exists(text) && mode == ReplayFileStreamMode.WriteOnly)
			{
				File.Delete(text);
			}
			return new ReplayFileStream(text, mode);
		}

		public void Update()
		{
		}

		public override void RecordSnapshot(ReplaySnapshot state)
		{
			lock (context)
			{
				context.header.duration = state.TimeStamp;
				context.chunk.Store(state);
				if (context.chunk.Count > 24)
				{
					ReplayFileChunk data = context.chunk.Clone();
					CreateTaskAsync(ReplayFileRequest.WriteChunk, ReplayFileTaskPriority.Normal, data);
					context.chunk = new ReplayFileChunk(++chunkIdGenerator);
				}
			}
		}

		public override ReplaySnapshot RestoreSnapshot(float offset)
		{
			bool flag = false;
			lock (context)
			{
				if (context.chunk.Restore(offset) == null)
				{
					if (context.buffer.HasLoadedChunk(offset))
					{
						LogReplayWarning("Using buffered chunk");
						context.chunk = context.buffer.GetLoadedChunk(offset);
					}
					else
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				ReplayFileTaskID taskID = CreateTaskAsync(ReplayFileRequest.FetchChunk, ReplayFileTaskPriority.High, new ReplayFileChunkFetchData(offset));
				WaitForSingleTask(taskID);
			}
			else
			{
				LogReplayMessage("An appropriate cached chunk was found and will be used to prevent chunk buffering");
			}
			lock (context)
			{
				int chunkID = context.chunk.chunkID;
				int num = ((base.PlaybackDirection == PlaybackDirection.Forward) ? 1 : (-1));
				int i;
				for (i = chunkID + num; context.buffer.HasLoadedChunk(i) && Mathf.Abs(i) < chunkCacheSize; i += num)
				{
				}
				if (!context.buffer.HasLoadedChunk(i) && !processingChunkRequests.Contains(i))
				{
					LogReplayWarning("Fetching next chunk: {0}", i);
					CreateTaskAsync(ReplayFileRequest.FetchChunkBuffered, ReplayFileTaskPriority.Normal, new ReplayFileChunkFetchData(i));
					if (!processingChunkRequests.Contains(i))
					{
						processingChunkRequests.Add(i);
					}
				}
				if (base.PlaybackDirection == PlaybackDirection.Forward)
				{
					context.buffer.ReleaseOldChunks(context.chunk.ChunkStartTime, ReplayFileEnumReleaseMode.ChunksBefore);
				}
				else
				{
					context.buffer.ReleaseOldChunks(context.chunk.ChunkEndTime, ReplayFileEnumReleaseMode.ChunksAfter);
				}
				return context.chunk.Restore(offset);
			}
		}

		public override void PrepareTarget(ReplayTargetTask mode)
		{
			switch (mode)
			{
			case ReplayTargetTask.Commit:
			{
				ReplayFileTaskID taskID6 = ReplayFileTaskID.empty;
				lock (context)
				{
					if (context.chunk.Count > 0)
					{
						ReplayFileChunk data = context.chunk.Clone();
						taskID6 = CreateTaskAsync(ReplayFileRequest.WriteChunk, ReplayFileTaskPriority.High, data);
						context.chunk = new ReplayFileChunk();
					}
				}
				if (!taskID6.Equals(ReplayFileTaskID.empty))
				{
					WaitForSingleTask(taskID6);
				}
				taskID6 = CreateTaskAsync(ReplayFileRequest.Commit, ReplayFileTaskPriority.High);
				WaitForSingleTask(taskID6);
				break;
			}
			case ReplayTargetTask.Discard:
			{
				ReplayFileTaskID taskID5 = CreateTaskAsync(ReplayFileRequest.Discard);
				WaitForSingleTask(taskID5);
				break;
			}
			case ReplayTargetTask.PrepareWrite:
			{
				context.fileStream = OpenFileStream(ReplayFileStreamMode.WriteOnly);
				context.header.sceneName = SceneManager.GetActiveScene().name;
				chunkIdGenerator = 0;
				ReplayFileTaskID taskID4 = CreateTaskAsync(ReplayFileRequest.WriteHeader, ReplayFileTaskPriority.High);
				WaitForSingleTask(taskID4);
				break;
			}
			case ReplayTargetTask.PrepareRead:
			{
				context.fileStream = OpenFileStream(ReplayFileStreamMode.ReadOnly);
				ReplayFileTaskID taskID = CreateTaskAsync(ReplayFileRequest.FetchHeader, ReplayFileTaskPriority.High);
				WaitForSingleTask(taskID);
				ReplayFileTaskID taskID2 = CreateTaskAsync(ReplayFileRequest.FetchTable, ReplayFileTaskPriority.High);
				WaitForSingleTask(taskID2);
				ReplayFileTaskID taskID3 = CreateTaskAsync(ReplayFileRequest.FetchStateBuffer, ReplayFileTaskPriority.High);
				WaitForSingleTask(taskID3);
				break;
			}
			}
		}

		private void CreateFetchAllChunksTask()
		{
			foreach (ReplayFileChunkTableEntry item in context.chunkTable)
			{
				CreateTaskAsync(ReplayFileRequest.FetchChunk, ReplayFileTaskPriority.Normal, new ReplayFileChunkFetchData(item.chunkID));
			}
		}

		private void ThreadWriteReplayChunk(ReplayFileChunk chunk)
		{
			LogReplayMessage("Attempting to write replay chunk '{0}' - streaming operation", chunk.chunkID);
			lock (context)
			{
				if (context.fileStream != null)
				{
					int filePointer = context.fileStream.Position - context.header.dataOffset;
					context.chunkTable.CreateEntry(chunk.chunkID, chunk.ChunkStartTime, chunk.ChunkEndTime, filePointer);
					chunk.OnReplayDataSerialize(context.fileStream.Writer);
				}
			}
		}

		private ReplayFileChunk ThreadReadReplayChunk(ReplayFileChunkFetchData fetchData)
		{
			if (context.fileStream == null)
			{
				return null;
			}
			int num = -1;
			if (fetchData.isIDBased)
			{
				LogReplayMessage("Attempting to fetch replay chunk with id '{0}'", fetchData.chunkID);
				num = context.chunkTable.GetPointerForChunk(fetchData.chunkID);
				if (num == -1)
				{
					LogReplayWarning("Failed to read replay chunk from file stream: With chunk id: '{0}'", fetchData.chunkID);
					return null;
				}
			}
			else
			{
				LogReplayMessage("Attempting to fetch replay chunk for timestamp '{0}'", fetchData.chunkTimeStamp);
				num = context.chunkTable.GetPointerForTimeStamp(fetchData.chunkTimeStamp);
				if (num == -1)
				{
					LogReplayWarning("Failed to read replay chunk from file stream: For time stamp: '{0}'", fetchData.chunkTimeStamp);
					return null;
				}
			}
			int num2 = context.header.dataOffset + num;
			context.fileStream.Seek(num2, SeekOrigin.Begin);
			ReplayFileChunk replayFileChunk = new ReplayFileChunk();
			replayFileChunk.OnReplayDataDeserialize(context.fileStream.Reader);
			return replayFileChunk;
		}

		private void ThreadCommitReplayFile()
		{
			LogReplayMessage("Begining replay file commit - The replay file will be finalized for loading");
			lock (context)
			{
				if (context.fileStream != null)
				{
					int position = context.fileStream.Position;
					ThreadWriteReplayChunkTable();
					int position2 = context.fileStream.Position;
					ThreadWriteInitialStateBuffer();
					context.fileStream.Seek(0L, SeekOrigin.Begin);
					context.header.chunkTableOffset = position;
					context.header.stateBufferOffset = position2;
					ThreadWriteReplayHeader();
					context.chunkTable = new ReplayFileChunkTable();
					context.chunk = new ReplayFileChunk();
					context.fileStream.Dispose();
					context.fileStream = null;
				}
			}
		}

		private void ThreadDiscardReplayFile()
		{
			LogReplayMessage("Discarding repay file recording at: {0}", FileOutputName);
			context.buffer.ReleaseAllChunks();
			context.header = default(ReplayFileHeader);
			context.chunkTable = new ReplayFileChunkTable();
			context.chunk = new ReplayFileChunk();
			if (context.fileStream != null)
			{
				context.fileStream.Clear();
				context.fileStream.Dispose();
				context.fileStream = null;
			}
			string path = TargetFileLocation;
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}

		private void ThreadWriteReplayHeader()
		{
			LogReplayMessage("Attempting to write replay file header");
			lock (context)
			{
				MemoryStream memoryStream = new MemoryStream();
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					context.header.OnReplayDataSerialize(writer);
					context.header.headerSize = (int)memoryStream.Length;
					context.header.dataOffset = (int)memoryStream.Length;
				}
				context.header.OnReplayDataSerialize(context.fileStream.Writer);
			}
		}

		private void ThreadWriteReplayChunkTable()
		{
			LogReplayMessage("Attempting to write replay file chunk table");
			lock (context)
			{
				if (context.fileStream != null)
				{
					context.chunkTable.OnReplayDataSerialize(context.fileStream.Writer);
				}
			}
		}

		private void ThreadWriteInitialStateBuffer()
		{
			LogReplayMessage("Attempting to write initial state buffer to file");
			lock (context)
			{
				if (context.fileStream != null)
				{
					context.initialStateBuffer.OnReplayDataSerialize(context.fileStream.Writer);
				}
			}
		}

		private void ThreadFetchReplayHeader()
		{
			LogReplayMessage("Attempting to fetch replay file header");
			ReplayFileHeader header = default(ReplayFileHeader);
			lock (context)
			{
				if (context.fileStream == null)
				{
					context.header = header;
					return;
				}
				context.fileStream.Seek(0L, SeekOrigin.Begin);
				header.OnReplayDataDeserialize(context.fileStream.Reader);
				context.header = header;
			}
		}

		private void ThreadFetchReplayChunkTable()
		{
			LogReplayMessage("Attempting to fetch replay chunk table");
			ReplayFileChunkTable replayFileChunkTable = new ReplayFileChunkTable();
			lock (context)
			{
				if (context.fileStream == null)
				{
					context.chunkTable = new ReplayFileChunkTable();
					return;
				}
				int chunkTableOffset = context.header.chunkTableOffset;
				context.fileStream.Seek(chunkTableOffset, SeekOrigin.Begin);
				replayFileChunkTable.OnReplayDataDeserialize(context.fileStream.Reader);
				context.chunkTable = replayFileChunkTable;
			}
		}

		private void ThreadFetchInitialStateBuffer()
		{
			LogReplayMessage("Attempting to fetch replay initial state buffer");
			ReplayInitialDataBuffer replayInitialDataBuffer = new ReplayInitialDataBuffer();
			lock (context)
			{
				if (context.fileStream == null)
				{
					context.initialStateBuffer = new ReplayInitialDataBuffer();
					return;
				}
				int stateBufferOffset = context.header.stateBufferOffset;
				context.fileStream.Seek(stateBufferOffset, SeekOrigin.Begin);
				replayInitialDataBuffer.OnReplayDataDeserialize(context.fileStream.Reader);
				context.initialStateBuffer = replayInitialDataBuffer;
			}
		}

		private ReplayFileTaskID CreateTaskAsync(ReplayFileRequest task, ReplayFileTaskPriority priority = ReplayFileTaskPriority.Normal, object data = null)
		{
			ReplayFileTaskID replayFileTaskID = ReplayFileTaskID.GenerateID();
			ReplayFileTaskRequest item = new ReplayFileTaskRequest
			{
				taskID = replayFileTaskID,
				task = task,
				priority = priority,
				data = data
			};
			lock (threadTasks)
			{
				threadTasks.Add(item);
				threadTasks.Sort((ReplayFileTaskRequest x, ReplayFileTaskRequest y) => x.priority.CompareTo(y.priority));
				return replayFileTaskID;
			}
		}

		private void WaitForSingleTask(ReplayFileTaskID taskID)
		{
			if (!threadStarted || !threadRunning)
			{
				throw new InvalidOperationException("File operations cannot be awaited due to the current state of the file streamer: Stream thread is not running");
			}
			while (true)
			{
				if (!streamThread.IsAlive)
				{
					throw new ThreadStateException("The stream thread was aborted unexpectedly. Waiting was canceled to avoid infinite waiting but this may cause the state of the file streamer to be corrupted");
				}
				bool flag = false;
				lock (threadTasks)
				{
					foreach (ReplayFileTaskRequest threadTask in threadTasks)
					{
						if (threadTask.taskID.Equals(taskID))
						{
							ReplayFileTaskID.ReleaseID(taskID);
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					Thread.Sleep(10);
					continue;
				}
				break;
			}
		}

		private void StreamThreadMain()
		{
			try
			{
				threadStarted = true;
				while (threadRunning)
				{
					if (StreamThreadHasTask())
					{
						StreamThreadProcessWaitingTask();
					}
				}
				while (StreamThreadHasTask())
				{
					StreamThreadProcessWaitingTask();
				}
			}
			catch (Exception exception)
			{
				Debug.LogError($"An exception caused the 'ReplayFileTarget' to fail (file stream thread : {streamThread.ManagedThreadId})");
				Debug.LogException(exception);
				threadRunning = false;
			}
		}

		private bool StreamThreadHasTask()
		{
			lock (threadTasks)
			{
				return threadTasks.Count > 0;
			}
		}

		private void StreamThreadProcessAllWaitingTasks()
		{
			while (StreamThreadHasTask())
			{
				StreamThreadProcessWaitingTask();
			}
		}

		private void StreamThreadProcessWaitingTask()
		{
			ReplayFileTaskRequest item;
			lock (threadTasks)
			{
				if (threadTasks.Count == 0)
				{
					return;
				}
				item = threadTasks[0];
			}
			switch (item.task)
			{
			case ReplayFileRequest.WriteChunk:
			{
				ReplayFileChunk chunk = item.data as ReplayFileChunk;
				ThreadWriteReplayChunk(chunk);
				break;
			}
			case ReplayFileRequest.FetchChunk:
			{
				ReplayFileChunkFetchData fetchData2 = (ReplayFileChunkFetchData)item.data;
				ReplayFileChunk replayFileChunk2 = ThreadReadReplayChunk(fetchData2);
				if (replayFileChunk2 != null)
				{
					lock (context)
					{
						context.chunk = replayFileChunk2;
						context.buffer.StoreChunk(replayFileChunk2);
					}
					if (processingChunkRequests.Contains(replayFileChunk2.chunkID))
					{
						processingChunkRequests.Remove(replayFileChunk2.chunkID);
					}
				}
				break;
			}
			case ReplayFileRequest.FetchChunkBuffered:
			{
				ReplayFileChunkFetchData fetchData = (ReplayFileChunkFetchData)item.data;
				lock (context)
				{
					if (context.buffer.HasLoadedChunk(fetchData.chunkID))
					{
						break;
					}
				}
				ReplayFileChunk replayFileChunk = ThreadReadReplayChunk(fetchData);
				if (replayFileChunk != null)
				{
					lock (context)
					{
						context.buffer.StoreChunk(replayFileChunk);
					}
					if (processingChunkRequests.Contains(replayFileChunk.chunkID))
					{
						processingChunkRequests.Remove(replayFileChunk.chunkID);
					}
				}
				break;
			}
			case ReplayFileRequest.Commit:
				ThreadCommitReplayFile();
				break;
			case ReplayFileRequest.Discard:
				ThreadDiscardReplayFile();
				break;
			case ReplayFileRequest.WriteHeader:
				ThreadWriteReplayHeader();
				break;
			case ReplayFileRequest.FetchHeader:
				ThreadFetchReplayHeader();
				break;
			case ReplayFileRequest.FetchTable:
				ThreadFetchReplayChunkTable();
				break;
			case ReplayFileRequest.FetchStateBuffer:
				ThreadFetchInitialStateBuffer();
				break;
			}
			lock (threadTasks)
			{
				if (threadTasks.Contains(item))
				{
					threadTasks.Remove(item);
				}
			}
		}

		public void LogReplayMessage(string format, params object[] args)
		{
			if (logDebugMessages)
			{
				Debug.Log("ReplayFileTarget (Experimental): " + string.Format(format, args));
			}
		}

		public void LogReplayWarning(string format, params object[] args)
		{
			Debug.LogWarning("ReplayFileTarget (Experimental): " + string.Format(format, args));
		}
	}
}
