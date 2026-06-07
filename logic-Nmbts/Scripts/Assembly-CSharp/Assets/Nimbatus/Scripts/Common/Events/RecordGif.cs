using System.IO;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using Moments;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Events
{
	public class RecordGif : MonoBehaviour
	{
		private Recorder _recorder;

		public UILabel ProgressLabel;

		public ShareGifPanel Panel;

		private string _labelText;

		private Texture[] _lastFrames;

		private bool _hasSaved;

		private string _lastPath;

		public void Start()
		{
			ShareGifPanel panel = Panel;
			if ((object)panel != null)
			{
				panel.gameObject.SetActive(false);
			}
			_recorder = Camera.main.GetComponent<Recorder>();
			if (_recorder != null)
			{
				_recorder.Record();
				string saveFolder = Application.dataPath + "/../Nimbatus_Screenshots/";
				_recorder.SaveFolder = saveFolder;
				_recorder.OnFileSaveProgress = OnFileSaveProgress;
				_recorder.OnFileSaved = OnFileSaved;
				_recorder.OnPreProcessingDone = OnPreprocessingDone;
			}
			ProgressLabel.text = "";
		}

		private void OnPreprocessingDone(Texture[] frames)
		{
			_lastFrames = frames;
		}

		private void OnFileSaveProgress(int id, float percent)
		{
			_labelText = LocalizationManager.GetTermTranslation("MainScene/CreatingGif");
		}

		private void OnFileSaved(int id, string filepath)
		{
			_lastPath = filepath;
			_hasSaved = true;
			_recorder.Record();
			_labelText = "";
		}

		private void Update()
		{
			if (_hasSaved)
			{
				_hasSaved = false;
			}
			if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CaptureGif) && !RuntimeGlobals.IsGameLoading && (Panel == null || !Panel.gameObject.activeInHierarchy))
			{
				string path = Application.dataPath + "/../Nimbatus_Screenshots/";
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				_recorder.Save();
				_labelText = LocalizationManager.GetTermTranslation("MainScene/CreatingGif");
			}
			ProgressLabel.text = _labelText;
		}
	}
}
