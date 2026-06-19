using System;
using System.IO;
using UnityEngine;

namespace Aggro.Core
{
	public class Tracer
	{
		private Stream _stream;

		private StreamWriter _writer;

		private int _indent;

		public Tracer(string filename)
		{
			lock (this)
			{
				string path = string.Format("{0}{1}Logs~{2}Traces{3}{4}-{5}.txt", Application.dataPath, Path.DirectorySeparatorChar, Path.DirectorySeparatorChar, Path.DirectorySeparatorChar, filename, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
				string directoryName = Path.GetDirectoryName(path);
				if (Directory.Exists(directoryName))
				{
					FileUtil.DeleteExtraFiles(directoryName);
				}
				else
				{
					Directory.CreateDirectory(directoryName);
				}
				_stream = File.Open(path, FileMode.Create, FileAccess.Write);
				_writer = new StreamWriter(_stream);
			}
		}

		~Tracer()
		{
			lock (this)
			{
				if (_stream != null)
				{
					_writer.Close();
					_writer.Dispose();
					_stream.Close();
					_stream.Dispose();
					_stream = null;
				}
			}
		}

		public void Trace(string msg)
		{
			lock (this)
			{
				_writer.WriteLine(GetTabs() + "[Log] " + msg);
			}
		}

		public void TraceWarning(string msg)
		{
			lock (this)
			{
				_writer.WriteLine(GetTabs() + "[Warning] " + msg);
			}
		}

		public void TraceError(string msg)
		{
			lock (this)
			{
				_writer.WriteLine(GetTabs() + "[Error] " + msg);
			}
		}

		public void IncrementIndent()
		{
			_indent++;
		}

		public void DecrementIndent()
		{
			_indent--;
		}

		private string GetTabs()
		{
			string text = "";
			for (int i = 0; i < _indent; i++)
			{
				text += "  ";
			}
			return text;
		}
	}
}
