using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using DV.UIFramework;
using Unity.SharpZipLib.Utils;
using UnityEngine;

namespace DV.UI
{
	public abstract class ABugReportDataProvider : MonoBehaviour
	{
		public struct PackingPath
		{
			public string Path;

			public string OutputPrefix;

			public PackingPath(string Path, string OutputPrefix = "")
			{
				this.Path = Path;
				this.OutputPrefix = OutputPrefix;
			}
		}

		public class ReportComponent
		{
			public delegate bool AvailabilityCheck();

			public delegate UniTask FilePacker(List<PackingPath> fileList);

			public delegate void FileCleaner();

			private AvailabilityCheck availabilityCheck;

			private FilePacker filePacker;

			private FileCleaner fileCleaner;

			public string Prefix { get; private set; }

			public ToggleDV Checkbox { get; private set; }

			public bool IsSelected
			{
				get
				{
					if (!Checkbox)
					{
						return true;
					}
					return Checkbox.isOn;
				}
			}

			public bool IsAvailable => availabilityCheck();

			public async UniTask Pack(List<PackingPath> fileList)
			{
				await filePacker(fileList);
			}

			public void CleanUp()
			{
				fileCleaner();
			}

			public ReportComponent(string prefix, ToggleDV toggle, AvailabilityCheck availability, FilePacker packer, FileCleaner cleaner)
			{
				Prefix = prefix;
				Checkbox = toggle;
				availabilityCheck = availability;
				filePacker = packer;
				fileCleaner = cleaner;
			}
		}

		public const string REPORT_DIR = "REPORT";

		public const int MAX_MESSAGE_LENGTH = 300;

		public async UniTask PackBasics(List<PackingPath> fileList, string description)
		{
			string name = Path.Combine(Application.persistentDataPath, "REPORT", "Description.txt");
			File.WriteAllText(name, description);
			await PackAdditionalBasics(fileList);
			fileList.Add(new PackingPath(name));
		}

		public void CleanupBasics()
		{
			File.Delete(Path.Combine(Application.persistentDataPath, "REPORT", "Description.txt"));
			CleanupAdditionalBasics();
		}

		public async UniTask PackingCoro(IEnumerable<ReportComponent> components, Action<string> onDone, Action<Exception> onError)
		{
			try
			{
				string stagingDir = Path.Combine(Application.persistentDataPath, "REPORT");
				if (Directory.Exists(stagingDir))
				{
					Directory.Delete(stagingDir, recursive: true);
				}
				Directory.CreateDirectory(stagingDir);
				foreach (ReportComponent component in components)
				{
					if (!component.IsSelected)
					{
						continue;
					}
					List<PackingPath> files = new List<PackingPath>();
					await component.Pack(files);
					if (files.Count == 0)
					{
						continue;
					}
					await UniTask.SwitchToThreadPool();
					Directory.CreateDirectory(Path.Combine(stagingDir, component.Prefix));
					foreach (PackingPath item in files)
					{
						string destFileName;
						if (string.IsNullOrEmpty(item.OutputPrefix))
						{
							destFileName = Path.Combine(stagingDir, component.Prefix, Path.GetFileName(item.Path));
						}
						else
						{
							string text = Path.Combine(stagingDir, component.Prefix, item.OutputPrefix);
							if (!Directory.Exists(text))
							{
								Directory.CreateDirectory(text);
							}
							destFileName = Path.Combine(text, Path.GetFileName(item.Path));
						}
						File.Copy(item.Path, destFileName);
					}
					await UniTask.SwitchToMainThread();
					component.CleanUp();
				}
				string packageName = "DV_BugReport_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip";
				string persistentDataPath = Application.persistentDataPath;
				await UniTask.SwitchToThreadPool();
				string text2 = Path.Combine(persistentDataPath, packageName);
				ZipUtility.CompressFolderToZip(text2, null, stagingDir);
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				File.Copy(text2, Path.Combine(folderPath, packageName), overwrite: true);
				Directory.Delete(stagingDir, recursive: true);
				File.Delete(text2);
				await UniTask.SwitchToMainThread();
				onDone?.Invoke(packageName);
			}
			catch (Exception obj)
			{
				await UniTask.SwitchToMainThread();
				onError?.Invoke(obj);
			}
		}

		public async UniTask PackCurrentLog(List<PackingPath> fileList)
		{
			string path = Path.Combine(Application.persistentDataPath, "Player.log");
			string path2 = Path.Combine(Application.persistentDataPath, "Player-prev.log");
			if (File.Exists(path))
			{
				fileList.Add(new PackingPath(path));
			}
			if (File.Exists(path2))
			{
				fileList.Add(new PackingPath(path2));
			}
		}

		public abstract bool IsReportingSupported();

		public virtual async UniTask PackAdditionalBasics(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupAdditionalBasics();

		public abstract bool CheckScreenshot();

		public abstract Texture GetScreenshotForPreview();

		public abstract (Texture texture, bool isTemporary) GetScreenshotForPacking();

		public abstract bool ShouldFlipScreenshotPreview();

		public abstract bool ShouldFlipScreenshotWhenSaving();

		public virtual async UniTask PackScreenshot(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupScreenshot();

		public abstract bool CheckSaveGames();

		public virtual async UniTask PackSaveGames(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupSaveGames();

		public abstract bool CheckTelemetry();

		public virtual async UniTask PackTelemetry(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupTelemetry();

		public abstract bool CheckGFXBenchmark();

		public virtual async UniTask PackGFXBenchmark(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupGFXBenchmark();

		public abstract bool CheckPhysicsBenchmark();

		public virtual async UniTask PackPhysicsBenchmark(List<PackingPath> fileList)
		{
		}

		public abstract void CleanupPhysicsBenchmark();
	}
}
