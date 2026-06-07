using System;
using System.Collections.Generic;
using UnityEngine;

namespace Toybox.Utilities.Save
{
	[Serializable]
	public class PlatformSaveFileList
	{
		[SerializeField]
		public List<PlatformSaveFile> platformSaveFileList;

		public PlatformSaveFileList(List<PlatformSaveFile> list)
		{
		}
	}
}
