using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class ContentBlockLayout : MonoBehaviour
	{
		[Serializable]
		public class BlockConfig
		{
			public string prefix;

			public string suffix;

			public string blockType;

			public bool immediateReset;

			public bool includeCurrentLine;

			public GameObject blockPrefab;
		}

		[SerializeField]
		private Container3DUIView _container;

		public static string TextBlockType;

		public static string FluffBlockType;

		public static string HeaderBlockType;

		public static string SubHeaderBlockType;

		public static string SubHeaderWithIconBlockType;

		public static string FlavourProfileBlockType;

		public static string ImageBlock;

		public List<BlockConfig> blockConfigs;

		private bool _isLayoutDirty;

		[Tooltip("If false, a header with no text block will be converted to a text block")]
		public bool allowSoloHeaders;

		public float defaultMaxRectWidth;

		public float minColliderWidth;

		public List<Action> CustomBlockUpdaters;

		public List<Action<float>> CustomBlockResizers;

		public List<BaseBlock3DUIView> Blocks { get; private set; }

		public event EventHandler LayoutChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void UpdateBlocks(string header, string textBlock, float maxWidth)
		{
		}

		private void UpdateBlockSizes(float maxWidth)
		{
		}

		private void UpdateCustomBlocks()
		{
		}

		private void ResizeCustomBlocks(float widestSize)
		{
		}

		public void UpdateLayout()
		{
		}
	}
}
