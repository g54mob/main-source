using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class RaceSpline : Spline
	{
		[Serializable]
		public class NodeSetting
		{
			public float Width;

			public float Offset;

			public bool KerbLeft = true;

			public bool KerbRight = true;

			public Material NextSegmentMaterial;

			public Material NextSegmentKerbMaterial;

			public bool OverrideTrackUvMode;

			public EUvStretchMode TrackUvMode = EUvStretchMode.SeamlessStretch;

			public bool OverrideKerbUvMode;

			public EUvStretchMode KerbUvMode = EUvStretchMode.SeamlessStretch;

			public bool ForkOut;

			public bool ForkIn;

			public RaceSpline ForkOutSpline;

			public List<RaceSpline> ForkInSplines = new List<RaceSpline>();

			public NodeSetting(float width)
			{
				Width = width;
			}

			public void Reset()
			{
				KerbLeft = true;
				KerbRight = true;
				OverrideTrackUvMode = false;
				OverrideKerbUvMode = false;
				ForkOut = false;
				ForkIn = false;
				ForkOutSpline = null;
				ForkInSplines.Clear();
			}
		}

		private struct PositionReturnData
		{
			public float RelativeNodePos;

			public int LastNodeIndex;

			public int NextNodeIndex;
		}

		public List<NodeSetting> NodeSettings = new List<NodeSetting>();

		[HideInInspector]
		public RaceSpline ForkTargetSpline;

		protected override void OnEnable()
		{
			base.OnEnable();
			NodeCountChanged.AddListener(UpdateNodeSettings);
			if (NodeSettings.Count == 0)
			{
				for (int i = 0; i < nodes.Count; i++)
				{
					NodeSettings.Add(new NodeSetting(1f));
				}
			}
		}

		public void UpdateNodeSettings()
		{
			if (nodes.Count > NodeSettings.Count)
			{
				NodeSettings.Insert(LastNodeAdded, new NodeSetting(1f));
			}
			else if (nodes.Count < NodeSettings.Count)
			{
				NodeSettings.Remove(NodeSettings[LastNodeRemoved]);
			}
		}

		private PositionReturnData PositionOnCurve(float distance)
		{
			PositionReturnData result = default(PositionReturnData);
			int i = 0;
			if (distance < 0f)
			{
				distance += Length;
			}
			else if (distance > Length)
			{
				distance -= Length;
			}
			for (; i < curves.Count - 1 && distance > curves[i].Length + float.Epsilon; i++)
			{
				distance -= curves[i].Length;
			}
			result.RelativeNodePos = distance / curves[i].Length;
			result.LastNodeIndex = i;
			result.NextNodeIndex = Mathf.Clamp(i + 1, 0, curves.Count);
			return result;
		}

		public float GetWidthModifierAtDistance(float distance)
		{
			PositionReturnData positionReturnData = PositionOnCurve(distance);
			return NodeSettings[positionReturnData.LastNodeIndex].Width + (NodeSettings[positionReturnData.NextNodeIndex].Width - NodeSettings[positionReturnData.LastNodeIndex].Width) * positionReturnData.RelativeNodePos;
		}

		public float GetOffsetAtDistance(float distance)
		{
			PositionReturnData positionReturnData = PositionOnCurve(distance);
			return NodeSettings[positionReturnData.LastNodeIndex].Offset + (NodeSettings[positionReturnData.NextNodeIndex].Offset - NodeSettings[positionReturnData.LastNodeIndex].Offset) * positionReturnData.RelativeNodePos;
		}
	}
}
