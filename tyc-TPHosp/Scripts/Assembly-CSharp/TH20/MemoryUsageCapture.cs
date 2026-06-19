#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using I2.Loc;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

namespace TH20
{
	public class MemoryUsageCapture : MustCallDestroy
	{
		private FileStream _fileStream;

		private StreamWriter _streamWriter;

		private float _nextMemoryLogTime;

		private Dictionary<Type, int> _typeDict = new Dictionary<Type, int>();

		private Type[] _loggedTypes;

		public MemoryUsageCapture()
		{
			_loggedTypes = new Type[18]
			{
				typeof(Material),
				typeof(Mesh),
				typeof(SkinnedMeshRenderer),
				typeof(ParticleSystem),
				typeof(GameObject),
				typeof(Transform),
				typeof(MeshRenderer),
				typeof(MeshFilter),
				typeof(RectTransform),
				typeof(CanvasRenderer),
				typeof(Image),
				typeof(LayoutElement),
				typeof(AudioClip),
				typeof(TextAsset),
				typeof(Texture2D),
				typeof(TextMeshProUGUI),
				typeof(Localize),
				typeof(LocalizeTarget_TextMeshPro_UGUI)
			};
			ConsoleCommandsDatabase.RegisterCommand("MemoryCaptureStartRecording", "Start recording memory usage data", "", Debug_StartRecording);
			ConsoleCommandsDatabase.RegisterCommand("MemoryCaptureStopRecording", "Stop recording memory usage data", "", Debug_StopRecording);
			ConsoleCommandsDatabase.RegisterCommand("MemoryCaptureDumpMaterials", "Dump Materials that are in Memory to file", "", Debug_DumpMaterials);
		}

		public void Update()
		{
			if (_streamWriter == null)
			{
				return;
			}
			_nextMemoryLogTime -= Time.unscaledDeltaTime;
			if (!(_nextMemoryLogTime < 0f))
			{
				return;
			}
			_nextMemoryLogTime += 30f;
			object[] array = new object[11 + _loggedTypes.Length];
			array[0] = DateTime.UtcNow.ToString();
			array[1] = Profiler.GetTotalReservedMemoryLong();
			array[2] = Profiler.GetTotalAllocatedMemoryLong();
			array[3] = Profiler.GetTotalUnusedReservedMemoryLong();
			array[4] = Profiler.GetAllocatedMemoryForGraphicsDriver();
			array[5] = Profiler.usedHeapSizeLong;
			array[6] = Profiler.GetMonoHeapSizeLong();
			array[7] = Profiler.GetMonoUsedSizeLong();
			UnityEngine.Object[] array2 = Resources.FindObjectsOfTypeAll<UnityEngine.Object>();
			array[8] = array2.Length;
			_typeDict.Clear();
			for (int i = 0; i < array2.Length; i++)
			{
				Type type = array2[i].GetType();
				if (_typeDict.ContainsKey(type))
				{
					_typeDict[type]++;
				}
				else
				{
					_typeDict[type] = 1;
				}
			}
			Type type2 = null;
			int num = 0;
			foreach (KeyValuePair<Type, int> item in _typeDict)
			{
				bool flag = false;
				for (int j = 0; j < _loggedTypes.Length; j++)
				{
					if (_loggedTypes[j] == item.Key)
					{
						flag = true;
						break;
					}
				}
				if (!flag && num < item.Value)
				{
					type2 = item.Key;
					num = item.Value;
				}
			}
			array[9] = type2.FullName;
			array[10] = num;
			for (int k = 0; k < _loggedTypes.Length; k++)
			{
				int value = 0;
				_typeDict.TryGetValue(_loggedTypes[k], out value);
				array[11 + k] = value;
			}
			for (int l = 0; l < array.Length; l++)
			{
				_streamWriter.Write($"{array[l]},");
			}
			_streamWriter.WriteLine();
			_streamWriter.Flush();
		}

		private ConsoleCommandResult Debug_DumpMaterials(params string[] args)
		{
			string text = Path.Combine(Directories.GameOutputDirectory, "Perf" + Path.DirectorySeparatorChar);
			Directory.CreateDirectory(text);
			string text2 = Path.Combine(text, "perf-materialDump.csv");
			Material[] array = Resources.FindObjectsOfTypeAll<Material>();
			using (FileStream stream = File.Create(text2))
			{
				using StreamWriter streamWriter = new StreamWriter(stream);
				streamWriter.WriteLine("Material Name, Shader Name, Main Texture Name");
				for (int i = 0; i < array.Length; i++)
				{
					streamWriter.WriteLine("{0},{1},{2}", array[i].name, (array[i].shader != null) ? array[i].shader.name : "null", (array[i].HasProperty("_MainTex") && array[i].mainTexture != null) ? array[i].mainTexture.name : "null");
				}
			}
			return ConsoleCommandResult.Succeeded($"Material Dump data saved to {text2}");
		}

		private ConsoleCommandResult Debug_StartRecording(params string[] args)
		{
			string text = Path.Combine(Directories.GameOutputDirectory, "Perf" + Path.DirectorySeparatorChar);
			Directory.CreateDirectory(text);
			string text2 = Path.Combine(text, "perf-memoryUsage.csv");
			Logging.Info("Saving Performance Capture Summary file {0}", text2);
			if (_fileStream != null)
			{
				_fileStream.Dispose();
			}
			_fileStream = File.Create(text2);
			_streamWriter = new StreamWriter(_fileStream);
			_streamWriter.Write("Date Time,Reserved Memory,Allocated Memory,Unused Reserved Memory,Allocated Memory For Graphics Driver,Used Heap Size,Mono Heap Size,Mono Used Size,Unity Objects Count,Most Common Unity Object Type (excluding logged types),Most Common Unity Object Count (excluding logged types),");
			for (int i = 0; i < _loggedTypes.Length; i++)
			{
				_streamWriter.Write("{0} Count,", _loggedTypes[i].FullName);
			}
			_streamWriter.WriteLine();
			return ConsoleCommandResult.Succeeded($"Memory Capture data saved to {text2}");
		}

		private ConsoleCommandResult Debug_StopRecording(params string[] args)
		{
			if (_streamWriter != null)
			{
				_streamWriter.Dispose();
				_streamWriter = null;
			}
			if (_fileStream != null)
			{
				_fileStream.Dispose();
				_fileStream = null;
			}
			_nextMemoryLogTime = 0f;
			return ConsoleCommandResult.Succeeded();
		}

		public override void Destroy()
		{
			if (_streamWriter != null)
			{
				_streamWriter.Dispose();
				_streamWriter = null;
			}
			if (_fileStream != null)
			{
				_fileStream.Dispose();
				_fileStream = null;
			}
			ConsoleCommandsDatabase.UnRegisterCommand("MemoryCaptureStartRecording");
			ConsoleCommandsDatabase.UnRegisterCommand("MemoryCaptureStopRecording");
			base.Destroy();
		}
	}
}
