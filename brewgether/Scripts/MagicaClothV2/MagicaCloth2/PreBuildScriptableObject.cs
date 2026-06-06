using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[CreateAssetMenu(fileName = "Data", menuName = "MagicaCloth2/PreBuildScriptableObject")]
	public class PreBuildScriptableObject : ScriptableObject
	{
		public List<SharePreBuildData> sharePreBuildDataList;

		public bool HasPreBuildData(string buildId)
		{
			return false;
		}

		public SharePreBuildData GetPreBuildData(string buildId)
		{
			return null;
		}

		public void AddPreBuildData(SharePreBuildData sdata)
		{
		}

		public void Warmup()
		{
		}
	}
}
