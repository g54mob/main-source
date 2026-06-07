using System;
using System.Collections.Generic;
using Placemaker.Audio;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropNode : MonoBehaviour, IComparable<PropNode>, IComparer<PropNode>
	{
		public float priority;

		public ManySoundsManager.SoundType appearanceSound;

		public PropAchievements.Achievement achievement;

		public bool turnedOn;

		public bool inDict;

		public bool hasBeenTurnedOn;

		public short hideCount;

		public short motivations;

		public List<PropNode> relations;

		public byte parentCount;

		public byte childCount;

		public byte overlapCount;

		public byte moteveeCount;

		public byte anchorCount;

		public int parentIndex => 0;

		public int childIndex => 0;

		public int overlapIndex => 0;

		public int moteveeIndex => 0;

		public int anchorIndex => 0;

		int IComparable<PropNode>.CompareTo(PropNode other)
		{
			return 0;
		}

		public void AddParent(PropNode node)
		{
		}

		public void AddChild(PropNode node)
		{
		}

		public void AddOverlap(PropNode node)
		{
		}

		public void AddMotevee(PropNode node)
		{
		}

		public void AddAnchor(PropNode node)
		{
		}

		public void RemoveParent(PropNode node)
		{
		}

		public void RemoveChild(PropNode node)
		{
		}

		public void RemoveOverlap(PropNode node)
		{
		}

		public void RemoveMotevee(PropNode node)
		{
		}

		public void RemoveAnchor(PropNode node)
		{
		}

		int IComparer<PropNode>.Compare(PropNode x, PropNode y)
		{
			return 0;
		}

		public void InserOverlap(PropNode node)
		{
		}
	}
}
