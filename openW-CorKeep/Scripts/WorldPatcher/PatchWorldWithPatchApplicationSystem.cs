using System;
using System.Diagnostics;
using System.IO;
using Pug.ECS.Serialization;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

[DisableAutoCreation]
public class PatchWorldWithPatchApplicationSystem : SystemBase
{
	public World DeserializeWorld;

	public DeserializationStates State;

	public string SaveFilePath;

	private Process process;

	private string patchFileOutputPath;

	private string pathLogFilePath;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		patchFileOutputPath = Path.Combine(Path.GetTempPath(), "Pugstorm", "patchingFile.patch");
		pathLogFilePath = Path.Combine(Path.GetTempPath(), "Pugstorm", "patchLog.txt");
	}

	[Preserve]
	protected override void OnDestroy()
	{
		process?.Kill();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (State == DeserializationStates.Patching && process == null)
		{
			StartPatchingProcess(SaveFilePath, patchFileOutputPath, pathLogFilePath);
		}
		base.OnStartRunning();
	}

	public void StartPatchingProcess(string fileSourcePath, string patchFileOutputPath, string logFilePath)
	{
		process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		processStartInfo.FileName = Application.streamingAssetsPath + "/Patcher/Windows/Core Keeper Patcher.exe";
		processStartInfo.Arguments = "-batchmode -nographics -logFile \"" + pathLogFilePath + "\" " + PatcherCommon.PatchSourceCommandArg + " \"" + fileSourcePath + "\" " + PatcherCommon.PatchOutputCommandArg + " \"" + patchFileOutputPath + "\"";
		processStartInfo.RedirectStandardInput = false;
		processStartInfo.RedirectStandardOutput = false;
		processStartInfo.RedirectStandardError = false;
		processStartInfo.CreateNoWindow = true;
		processStartInfo.UseShellExecute = false;
		process.StartInfo = processStartInfo;
		try
		{
			bool flag = process.Start();
			UnityEngine.Debug.Log($"Started patch process successful: {flag}");
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Error starting patch process: " + ex.Message);
			process.Close();
			process = null;
			State = DeserializationStates.SaveFileCorrupt;
		}
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (State != DeserializationStates.Patching || process == null || !process.HasExited)
		{
			return;
		}
		process = null;
		World deserializeWorld = DeserializeWorld;
		if (deserializeWorld == null)
		{
			throw new InvalidOperationException("DeserializeWorld == null");
		}
		string text = patchFileOutputPath;
		try
		{
			if (SerializedWorldPatchFileLoader.TryLoadPatchedWorld(text, deserializeWorld))
			{
				State = DeserializationStates.Finished;
				UnityEngine.Debug.Log("Patching successful");
			}
			else
			{
				State = DeserializationStates.SaveFileCorrupt;
				UnityEngine.Debug.LogError("Error patching");
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			State = DeserializationStates.SaveFileCorrupt;
		}
		if (File.Exists(text))
		{
			File.Delete(text);
		}
	}

	[Preserve]
	public PatchWorldWithPatchApplicationSystem()
	{
	}
}
