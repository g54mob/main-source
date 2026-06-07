using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Elements
{
	public class AudioSampleAssetInspector : AssetInspector
	{
		public UIButton playButton;

		public UIButton pauseButton;

		public UIButton stopButton;

		public UIText songTitle;

		public UIText artistName;

		private AudioSource audioSource;

		private float[] samples;

		private float[] spectrum;

		private float sampleRate;

		private const int SAMPLE_SIZE = 1024;

		private float rmsValue;

		private float dbValue;

		private float pitchValue;

		private Transform[] visualList;

		private float[] visualScale;

		public override void Init(Action delete, Action edit, Action<string> rename, Action<string> duplicate, List<string> existingNames, Action<string> export, AssetType assetType = AssetType.AudioSample)
		{
		}

		public override void ActivateAssetInspector(Asset data)
		{
		}

		public override void OpenExportDialog()
		{
		}

		public override void OnExport(string name)
		{
		}
	}
}
