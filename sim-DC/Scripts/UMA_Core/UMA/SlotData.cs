using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class SlotData : IEquatable<SlotData>, ISerializationCallbackReceiver
	{
		public SlotDataAsset asset;

		public float overlayScale;

		public string[] tags;

		public string[] Races;

		public List<MeshModifier.Modifier> meshModifiers;

		public string blendShapeTargetSlot;

		public int expandAlongNormal;

		public float overSmoosh;

		public float smooshDistance;

		public bool smooshInvertX;

		public bool smooshInvertY;

		public bool smooshInvertZ;

		public bool smooshInvertDist;

		public string smooshTargetTag;

		public string smooshableTag;

		public bool isSwapSlot;

		public string swapTag;

		public int skinnedMeshRenderer;

		public int submeshIndex;

		public int vertexOffset;

		public Rect UVArea;

		public bool tempHidden;

		public bool isDisabled;

		public int UVSet;

		public UMAMaterial altMaterial;

		public List<string> BlendshapeSlotNames;

		public bool Suppressed;

		public bool dontSerialize;

		private List<OverlayData> overlayList;

		public BitArray[] meshHideMask;

		public UMARendererAsset rendererAsset;

		public bool hasAdjustments => false;

		public bool isBlendShapeSource => false;

		public bool UVRemapped => false;

		public bool useAtlasOverlay => false;

		public int MaxLod => 0;

		public UMAMaterial material => null;

		public string slotName => null;

		public int OverlayCount => 0;

		public Vector2 ConvertToAtlasUV(Vector2 uvIn)
		{
			return default(Vector2);
		}

		public SlotData(SlotDataAsset asset)
		{
		}

		public SlotData()
		{
		}

		public UMABlendShape GetBlendshape(string name)
		{
			return null;
		}

		public bool HasRace(string raceName)
		{
			return false;
		}

		public bool HasTag(List<string> tagList)
		{
			return false;
		}

		public bool HasTag(string[] tagList)
		{
			return false;
		}

		public Dictionary<string, List<OverlayData>> GetOverlaysByTag(string tag)
		{
			return null;
		}

		public bool HasTag(string tag)
		{
			return false;
		}

		public SlotData Copy()
		{
			return null;
		}

		public void RemoveOverlayTags(List<string> HideTags)
		{
		}

		public bool RemoveOverlay(params string[] names)
		{
			return false;
		}

		public bool SetOverlayColor(Color32 color, params string[] names)
		{
			return false;
		}

		public OverlayData GetOverlay(params string[] names)
		{
			return null;
		}

		public void SetOverlay(int index, OverlayData overlay)
		{
		}

		public OverlayData GetOverlay(int index)
		{
			return null;
		}

		public OverlayData GetEquivalentOverlay(OverlayData overlay)
		{
			return null;
		}

		public OverlayData GetEquivalentUsedOverlay(OverlayData overlay)
		{
			return null;
		}

		public void SetOverlayList(List<OverlayData> newOverlayList)
		{
		}

		public void UpdateOverlayList(List<OverlayData> newOverlayList)
		{
		}

		public void AddOverlay(OverlayData overlayData)
		{
		}

		public void AddOverlayList(List<OverlayData> newOverlays)
		{
		}

		public List<OverlayData> GetOverlayList()
		{
			return null;
		}

		internal bool Validate()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator bool(SlotData obj)
		{
			return false;
		}

		public bool Equals(SlotData other)
		{
			return false;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public static bool operator ==(SlotData slot, SlotData obj)
		{
			return false;
		}

		public static bool operator !=(SlotData slot, SlotData obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
