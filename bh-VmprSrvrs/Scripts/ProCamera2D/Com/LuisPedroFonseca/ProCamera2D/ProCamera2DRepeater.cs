using System.Collections.Generic;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-repeater/")]
	public class ProCamera2DRepeater : BasePC2D, IPostMover
	{
		public static string ExtensionName;

		public Transform ObjectToRepeat;

		public Vector2 ObjectSize;

		public Vector2 ObjectBottomLeft;

		public bool ObjectOnStage;

		public bool _repeatHorizontal;

		public bool _repeatVertical;

		public Camera CameraToUse;

		private Transform _cameraToUseTransform;

		private Vector3 _objStartPosition;

		private List<RepeatedObject> _allRepeatedObjects;

		private Queue<RepeatedObject> _inactiveRepeatedObjects;

		private IntPoint _prevStartIndex;

		private IntPoint _prevEndIndex;

		private Dictionary<IntPoint, bool> _occupiedIndices;

		private int _pmOrder;

		public bool RepeatHorizontal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RepeatVertical
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int PMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public void PostMove(float deltaTime)
		{
		}

		public void SetRepeatingObject(Transform objectToRepeat, bool isExistingObject)
		{
		}

		private void FreeOutOfRangeObjects(IntPoint startIndex, IntPoint endIndex)
		{
		}

		private void FillGrid(IntPoint startIndex, IntPoint endIndex)
		{
		}

		private void InitCopy(Transform newCopy, bool positionOffscreen = true)
		{
		}

		private void PositionObject(RepeatedObject obj, IntPoint index)
		{
		}

		private void Refresh()
		{
		}
	}
}
