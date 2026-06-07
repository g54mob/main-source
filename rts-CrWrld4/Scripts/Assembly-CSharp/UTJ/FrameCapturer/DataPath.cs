using System;
using UnityEngine;

namespace UTJ.FrameCapturer
{
	[Serializable]
	public class DataPath
	{
		public enum Root
		{
			Absolute = 0,
			Current = 1,
			PersistentData = 2,
			StreamingAssets = 3,
			TemporaryCache = 4,
			DataPath = 5
		}

		[SerializeField]
		private Root m_root;

		[SerializeField]
		private string m_leaf;

		public Root root
		{
			get
			{
				return default(Root);
			}
			set
			{
			}
		}

		public string leaf
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool readOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public DataPath()
		{
		}

		public DataPath(Root root, string leaf)
		{
		}

		public DataPath(string path)
		{
		}

		public string GetFullPath()
		{
			return null;
		}

		public void CreateDirectory()
		{
		}
	}
}
