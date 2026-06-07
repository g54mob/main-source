using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class ReadableId
	{
		[SerializeField]
		private string m_name;

		[SerializeField]
		private string m_id;

		public string Name => null;

		public string Id => null;

		public ReadableId(string name, string id)
		{
		}
	}
}
