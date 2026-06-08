using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	[RequireComponent(typeof(BoxCollider))]
	[RequireComponent(typeof(HingeJoint))]
	public class PhaseWhenStuck : MonoBehaviour
	{
		public HingeJoint Joint;

		public BoxCollider Collider;

		public float OpenTimer;

		public float PhaseTime;

		public Material PhaseMaterial;

		public List<Renderer> ReplaceRenderersDuringPhasing = new List<Renderer>();

		private List<Material> MaterialsReplaced = new List<Material>();

		private MemoryManagerHandle Handle => this;

		private void Awake()
		{
			Joint = GetComponent<HingeJoint>();
			Collider = GetComponent<BoxCollider>();
			if (ReplaceRenderersDuringPhasing == null)
			{
				return;
			}
			if (MaterialsReplaced == null)
			{
				MaterialsReplaced = new List<Material>();
			}
			foreach (Renderer item in ReplaceRenderersDuringPhasing)
			{
				MaterialsReplaced.Add(item.material);
				Handle.Register(item.material);
			}
		}

		private void SetMaterials(bool is_phased)
		{
			if (ReplaceRenderersDuringPhasing == null || PhaseMaterial == null)
			{
				return;
			}
			for (int i = 0; i < ReplaceRenderersDuringPhasing.Count; i++)
			{
				Renderer renderer = ReplaceRenderersDuringPhasing[i];
				if (is_phased)
				{
					renderer.sharedMaterial = PhaseMaterial;
				}
				else
				{
					renderer.material = MaterialsReplaced[i];
				}
			}
		}

		private void Update()
		{
			if (PhaseTime > 0f)
			{
				PhaseTime -= Time.deltaTime;
				if (PhaseTime <= 0f)
				{
					OpenTimer = 0f;
					SetMaterials(is_phased: false);
					Collider.enabled = true;
				}
			}
			else if (Mathf.Abs(Joint.angle - Joint.spring.targetPosition) > 10f)
			{
				OpenTimer += Time.deltaTime;
				if (OpenTimer > 4f)
				{
					PhaseTime = 3f;
					SetMaterials(is_phased: true);
					Collider.enabled = false;
				}
			}
			else
			{
				OpenTimer = 0f;
			}
		}
	}
}
