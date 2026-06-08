using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class DoorController : MonoBehaviour
	{
		public HingeJoint Hinge;

		public float TargetPosition = 70f;

		public GameObject Door;

		private Vector3 DoorDefaultPosition;

		private Quaternion DoorDefaultRotation;

		private bool HasSetPositions;

		public Collider Collider;

		public bool IsExternal;

		public List<Renderer> ReplaceRenderersDuringPhasing = new List<Renderer>();

		private List<Material> MaterialsReplaced = new List<Material>();

		private MemoryManagerHandle Handle => this;

		private void Start()
		{
			SetPositions();
			foreach (Renderer item in ReplaceRenderersDuringPhasing)
			{
				MaterialsReplaced.Add(item.material);
				Handle.Register(item.material);
			}
		}

		private void OnDestroy()
		{
			Handle.Dispose();
		}

		private void SetPositions()
		{
			DoorDefaultPosition = Door.transform.localPosition;
			DoorDefaultRotation = Door.transform.localRotation;
			HasSetPositions = true;
		}

		private void SetClosed()
		{
			JointSpring spring = Hinge.spring;
			spring.spring = 1f;
			spring.damper = 1f;
			spring.targetPosition = 0f;
			Hinge.spring = spring;
			Hinge.useSpring = true;
			if (IsExternal)
			{
				Collider.enabled = true;
			}
		}

		private void SetOpen()
		{
			JointSpring spring = Hinge.spring;
			spring.spring = 10f;
			spring.damper = 3f;
			spring.targetPosition = TargetPosition;
			Hinge.spring = spring;
			Hinge.useSpring = true;
			if (IsExternal)
			{
				Collider.enabled = false;
			}
		}

		public void ResetAngle()
		{
			if (!HasSetPositions)
			{
				SetPositions();
			}
			Door.transform.localPosition = DoorDefaultPosition;
			Door.transform.localRotation = DoorDefaultRotation;
		}

		public void SetSpring(bool active)
		{
			if (active)
			{
				SetOpen();
			}
			else
			{
				SetClosed();
			}
		}

		public void SetCollision(bool enabled)
		{
			if (!IsExternal)
			{
				Collider.enabled = enabled;
			}
		}
	}
}
