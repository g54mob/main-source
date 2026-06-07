using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/PermanenceTextureMappingDatabase")]
	public class PermanenceTextureMappingDatabase : ScriptableObject
	{
		[Serializable]
		public struct ZoneAddress
		{
			public static readonly ZoneAddress Center = new ZoneAddress(TileDirection.None, TileDirection.None, TileDirection.None, ZoneSharing.Local);

			public TileDirection tile;

			public TileDirection section;

			public TileDirection insideSection;

			public ZoneSharing sharingStatus;

			public static ZoneAddress LocalDirection(TileDirection direction)
			{
				return new ZoneAddress(TileDirection.None, direction, TileDirection.None, ZoneSharing.Local);
			}

			public ZoneAddress(TileDirection tile, TileDirection section, TileDirection insideSection, ZoneSharing sharingStatus)
			{
				this.tile = tile;
				this.section = section;
				this.insideSection = insideSection;
				this.sharingStatus = sharingStatus;
			}

			public bool Equals(ZoneAddress other)
			{
				if (tile == other.tile && section == other.section && insideSection == other.insideSection)
				{
					return sharingStatus == other.sharingStatus;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is ZoneAddress other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)(((((uint)((int)tile * 397) ^ (uint)section) * 397) ^ (uint)insideSection) * 397) ^ (int)sharingStatus;
			}

			public static bool operator ==(ZoneAddress a, ZoneAddress b)
			{
				return a.Equals(b);
			}

			public static bool operator !=(ZoneAddress a, ZoneAddress b)
			{
				return !a.Equals(b);
			}

			public override string ToString()
			{
				return tile.ToShortString() + ", " + section.ToShortString() + ", " + insideSection.ToShortString() + ", " + sharingStatus;
			}
		}

		public enum ZoneType
		{
			Solid = 0,
			Fade = 1,
			Quadrant = 2
		}

		public enum ZoneSharing
		{
			Local = 0,
			Shared = 1,
			Phantom = 2
		}

		[Serializable]
		public struct GenerationIndexToZoneIdMapping
		{
			[FormerlySerializedAs("zoneStartId")]
			public int zoneId;

			public int fadeFromIndexA;

			public int fadeToIndexA;

			public int fadeFromIndexB;

			public int fadeToIndexB;

			[FormerlySerializedAs("shaderStartIndex")]
			public int shaderIndex;

			public ZoneType zoneType;

			public TileDirection sectionDirection;

			public TileDirection insideSectionDirection;

			public ZoneAddress fadeFromZoneA;

			public ZoneAddress fadeToZoneA;

			public ZoneAddress fadeFromZoneB;

			public ZoneAddress fadeToZoneB;

			public ZoneSharing SharingStatus
			{
				get
				{
					if (shaderIndex < 49)
					{
						return ZoneSharing.Local;
					}
					if (shaderIndex < 85)
					{
						return ZoneSharing.Shared;
					}
					return ZoneSharing.Phantom;
				}
			}

			public string GetDisplayString(int index)
			{
				return $"{index}: ({shaderIndex}) -> ({zoneId})  | ({fadeFromIndexA}, {fadeToIndexA}, {fadeFromIndexB}, {fadeToIndexB})";
			}
		}

		public VisualConstantsData visualConstantsData;

		[FormerlySerializedAs("shaderToIdMappings")]
		public List<GenerationIndexToZoneIdMapping> generationIndexToZoneIdMappings = new List<GenerationIndexToZoneIdMapping>();

		public float[] shaderIndexToZoneIndex;

		public Vector4[] zoneIndexToFadeIndices;

		[FormerlySerializedAs("solidZoneShaderIds")]
		public ZoneAddress[] solidZoneShaderIndices;

		public int ShaderSolidZoneCount => solidZoneShaderIndices.Length;

		public event Action OnTextureMappingsUpdated;

		public void RefreshBakedData()
		{
			for (int i = 0; i < generationIndexToZoneIdMappings.Count; i++)
			{
				GenerationIndexToZoneIdMapping value = generationIndexToZoneIdMappings[i];
				value.zoneId = i;
				generationIndexToZoneIdMappings[i] = value;
			}
			FillShaderIndexToZoneIndexArray(generationIndexToZoneIdMappings.Count);
			CalculateSolidZoneShaderIndices();
			for (int j = 0; j < generationIndexToZoneIdMappings.Count; j++)
			{
				GenerationIndexToZoneIdMapping value2 = generationIndexToZoneIdMappings[j];
				value2.fadeFromIndexB = -1;
				value2.fadeToIndexB = -1;
				if (value2.zoneType == ZoneType.Solid)
				{
					ZoneAddress zoneAddress = new ZoneAddress(TileDirection.None, value2.sectionDirection, value2.insideSectionDirection, value2.SharingStatus);
					value2.fadeToIndexA = (value2.fadeFromIndexA = FindShaderSolidZoneIndex(zoneAddress));
				}
				else
				{
					value2.fadeFromIndexA = FindShaderSolidZoneIndex(value2.fadeFromZoneA);
					value2.fadeToIndexA = FindShaderSolidZoneIndex(value2.fadeToZoneA);
					if (value2.zoneType == ZoneType.Quadrant)
					{
						value2.fadeFromIndexB = FindShaderSolidZoneIndex(value2.fadeFromZoneB);
						value2.fadeToIndexB = FindShaderSolidZoneIndex(value2.fadeToZoneB);
					}
				}
				generationIndexToZoneIdMappings[j] = value2;
			}
			zoneIndexToFadeIndices = new Vector4[generationIndexToZoneIdMappings.Count];
			foreach (GenerationIndexToZoneIdMapping generationIndexToZoneIdMapping in generationIndexToZoneIdMappings)
			{
				zoneIndexToFadeIndices[generationIndexToZoneIdMapping.zoneId] = new Vector4(generationIndexToZoneIdMapping.fadeFromIndexA, generationIndexToZoneIdMapping.fadeToIndexA, generationIndexToZoneIdMapping.fadeFromIndexB, generationIndexToZoneIdMapping.fadeToIndexB);
			}
			this.OnTextureMappingsUpdated?.Invoke();
		}

		private void CalculateSolidZoneShaderIndices()
		{
			List<ZoneAddress> list = new List<ZoneAddress>();
			list.Clear();
			foreach (GenerationIndexToZoneIdMapping generationIndexToZoneIdMapping in generationIndexToZoneIdMappings)
			{
				if (generationIndexToZoneIdMapping.zoneType != ZoneType.Solid)
				{
					list.Add(generationIndexToZoneIdMapping.fadeFromZoneA);
					list.Add(generationIndexToZoneIdMapping.fadeToZoneA);
					if (generationIndexToZoneIdMapping.zoneType == ZoneType.Quadrant)
					{
						list.Add(generationIndexToZoneIdMapping.fadeFromZoneB);
						list.Add(generationIndexToZoneIdMapping.fadeToZoneB);
					}
				}
			}
			list = list.Distinct().ToList();
			list.Sort(delegate(ZoneAddress a, ZoneAddress b)
			{
				if (a.tile == b.tile)
				{
					if (a.sharingStatus == b.sharingStatus)
					{
						if (a.section == b.section)
						{
							return 0;
						}
						return a.section - b.section;
					}
					if (a.sharingStatus != ZoneSharing.Local)
					{
						return 1;
					}
					return -1;
				}
				return a.tile - b.tile;
			});
			solidZoneShaderIndices = list.ToArray();
		}

		public int FindShaderSolidZoneIndex(ZoneAddress zoneAddress)
		{
			for (int i = 0; i < solidZoneShaderIndices.Length; i++)
			{
				ZoneAddress zoneAddress2 = solidZoneShaderIndices[i];
				if (zoneAddress == zoneAddress2)
				{
					return i;
				}
			}
			return -1;
		}

		private void FillShaderIndexToZoneIndexArray(int newArraySize)
		{
			shaderIndexToZoneIndex = new float[newArraySize];
			for (int i = 0; i < shaderIndexToZoneIndex.Length; i++)
			{
				shaderIndexToZoneIndex[i] = 1000f;
			}
			foreach (GenerationIndexToZoneIdMapping generationIndexToZoneIdMapping in generationIndexToZoneIdMappings)
			{
				shaderIndexToZoneIndex[generationIndexToZoneIdMapping.shaderIndex] = generationIndexToZoneIdMapping.zoneId;
			}
		}
	}
}
