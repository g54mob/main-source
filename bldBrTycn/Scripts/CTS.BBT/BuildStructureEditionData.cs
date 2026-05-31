using System;
using CTS.Core;
using UnityEngine;

public class BuildStructureEditionData : AbsEditionData
{
	[Serializable]
	public struct RoomEditorStruct
	{
		[field: SerializeField]
		public Vector2Int Position { get; private set; }

		[field: SerializeField]
		public Vector2Int Size { get; private set; }
	}

	[field: SerializeField]
	public RoomEditorStruct[] StructData { get; private set; }

	[field: SerializeField]
	public int RoomID { get; private set; }

	public override void Generate()
	{
		for (int i = 0; i < StructData.Length; i++)
		{
			MonoSingleton<ConstructionSystem>.Instance.CreateSectorFromEditor(StructData[i].Position, StructData[i].Size, EConstructionMode.Construction);
		}
	}
}
