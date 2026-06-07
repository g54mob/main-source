using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Gh.Tk
{
	public class GeneralBuilder : BaseBuilder
	{
		private bool _isFreeRotating;

		private Vector2 _lastMousePositionPreFreeRotate;

		public const float DefaultRotationDegree = 45f;

		protected Vector3 _startingRotation;

		private List<GameObject> _outDoorBuildAreaVisuals;

		private GameObject _outDoorBuildAreaVisualParent;

		private static readonly NNConstraint NnConstraint;

		private GameObject _outDoorBuildHelper;

		public bool IsFreeRotating
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public GameObject ClickedObject { get; internal set; }

		public override bool IsBuilding => false;

		private void Start()
		{
		}

		private void OnGridChanged(object sender, EventArgs e)
		{
		}

		public override void EnterBuildMode(Vector3 coords)
		{
		}

		private void ShowOutDoorBuildArea()
		{
		}

		private void InitializeOutdoorBuildAreaVisuals()
		{
		}

		private void HideOutDoorBuildArea()
		{
		}

		public static void SetMeshVisibility(GameObject old, GameObject @new)
		{
		}

		public override void ExitBuildMode(bool switchInputMode = true)
		{
		}

		protected virtual void Build()
		{
		}

		public override void Refresh()
		{
		}

		private void SetBuildablePosition(Vector3 coords)
		{
		}

		public override void ExitEditMode(bool resetPosition = false)
		{
		}

		public override void EnterEditMode(Buildable selectedBuildable)
		{
		}

		public override bool Esc()
		{
			return false;
		}
	}
}
