using System;
using System.IO;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Persistent;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Window
{
	[Obfuscation(Exclude = true)]
	public class SystemMonitorWindow : MonitorWindow
	{
		[Header("System Window - Settings")]
		[Tooltip("The UI Text component displaying the operating system information.")]
		public Text OperatingSystemText;

		[Tooltip("The UI Text component displaying device-related information.")]
		public Text DeviceText;

		[Tooltip("The UI Text component displaying processor details.")]
		public Text ProcessorText;

		[Tooltip("The UI Text component displaying memory-related information.")]
		public Text MemorySizeText;

		[Tooltip("The UI Text component displaying graphic device details.")]
		public Text GraphicDeviceText;

		[Tooltip("The UI Text component displaying graphic memory size information.")]
		public Text GraphicMemorySizeText;

		[Tooltip("Save the system information on start to a file in 'Application.persistentDataPath'.")]
		public bool SaveToFile;

		protected override void Start()
		{
			base.Start();
			string operatingSystem = SystemInfo.operatingSystem;
			string text = SystemInfo.operatingSystemFamily.ToString();
			OperatingSystemText.text = text + " - " + operatingSystem;
			string deviceModel = SystemInfo.deviceModel;
			string text2 = SystemInfo.deviceType.ToString();
			DeviceText.text = text2 + " - " + deviceModel;
			string processorType = SystemInfo.processorType;
			string text3 = SystemInfo.processorCount.ToString();
			string text4 = string.Format("{0:0.0}{1}", (float)SystemInfo.processorFrequency * 0.001f, "GHz");
			ProcessorText.text = processorType + " (" + text3 + "x " + text4 + ")";
			string text5 = string.Format("{0:0.0}{1}", (float)SystemInfo.systemMemorySize / 1024f, "GB");
			MemorySizeText.text = text5;
			string graphicsDeviceName = SystemInfo.graphicsDeviceName;
			string text6 = SystemInfo.graphicsDeviceType.ToString();
			GraphicDeviceText.text = graphicsDeviceName + " (" + text6 + ")";
			string text7 = string.Format("{0:0.0}{1}", (float)SystemInfo.graphicsMemorySize / 1024f, "GB");
			GraphicMemorySizeText.text = text7;
			if (SaveToFile)
			{
				DateTime now = DateTime.Now;
				now.AddSeconds(0f - Time.realtimeSinceStartup);
				string text8 = now.ToString("yyyy.MM.dd_HH.mm.ss");
				StringFileWriter stringFileWriter = new StringFileWriter(Path.Combine(Application.persistentDataPath, text8 + "_SystemInfo.txt"));
				stringFileWriter.Write("Operating System: " + text + " - " + operatingSystem);
				stringFileWriter.Write("Device: " + text2 + " - " + deviceModel);
				stringFileWriter.Write("Processor: " + processorType + " (" + text3 + "x " + text4 + ")");
				stringFileWriter.Write("Memory: " + text5);
				stringFileWriter.Write("Graphic Device: " + graphicsDeviceName + " (" + text6 + ")");
				stringFileWriter.Write("Graphic Memory: " + text7);
				stringFileWriter.Flush();
				stringFileWriter.Dispose();
			}
		}
	}
}
