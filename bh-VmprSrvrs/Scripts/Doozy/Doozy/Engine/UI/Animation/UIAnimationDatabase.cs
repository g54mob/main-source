using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class UIAnimationDatabase : ScriptableObject
	{
		public List<string> AnimationNames;

		public List<UIAnimationData> Database;

		public string DatabaseName;

		public AnimationType DataType;

		private static UILanguagePack UILabels => null;

		public bool Add(UIAnimation animation, string animationName, bool saveAssets = true)
		{
			return false;
		}

		public UIAnimationData AddDefaultData(bool saveAssets)
		{
			return null;
		}

		public bool Contains(string animationName)
		{
			return false;
		}

		public bool Contains(UIAnimationData data)
		{
			return false;
		}

		public void CreatePreset(string newPresetName, UIAnimation animation, bool saveAssets = true)
		{
		}

		public bool Delete(string animationName, bool saveAssets)
		{
			return false;
		}

		public bool Delete(UIAnimationData data, bool saveAssets)
		{
			return false;
		}

		public UIAnimationData Get(string animationName)
		{
			return null;
		}

		public void RefreshDatabase(bool saveAssets)
		{
		}

		public void RemoveNullEntries(bool saveAssets)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void Sort(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		private void UpdateAnimationNames(bool saveAssets)
		{
		}

		private void AddObjectToAsset(UnityEngine.Object objectToAdd)
		{
		}

		private void Rename(string oldAnimationName, string newAnimationName)
		{
		}

		private void RenameAssetFileNamesToReflectAnimationNames()
		{
		}
	}
}
