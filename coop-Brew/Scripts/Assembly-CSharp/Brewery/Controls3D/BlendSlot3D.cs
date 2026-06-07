using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	[RequireComponent(typeof(Collider))]
	public class BlendSlot3D : MonoBehaviour
	{
		[Header("Visual")]
		[Tooltip("Icon GameObjects for each material type (index matches BlendMaterialType enum - 1).")]
		[SerializeField]
		private GameObject yeastIcon;

		[SerializeField]
		private GameObject sugarIcon;

		[SerializeField]
		private GameObject nutrientsIcon;

		[SerializeField]
		private GameObject tanninIcon;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig fillAnimation;

		[SerializeField]
		private TweenConfig clearAnimation;

		private BlendMaterialType currentMaterial;

		private GameObject activeIcon;

		private int tweenId;

		private Collider cachedCollider;

		private Vector3 yeastScale;

		private Vector3 sugarScale;

		private Vector3 nutrientsScale;

		private Vector3 tanninScale;

		public BlendMaterialType CurrentMaterial => default(BlendMaterialType);

		public bool IsEmpty => false;

		public event Action<BlendSlot3D> OnSlotChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<BlendSlot3D> OnSlotClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SetMaterial(BlendMaterialType material)
		{
		}

		public void Clear()
		{
		}

		public void Snap(BlendMaterialType material)
		{
		}

		private void HideAllIconsImmediate()
		{
		}

		private static void CancelAndHide(GameObject icon, Vector3 restoreScale)
		{
		}

		private static void DisableColliders(GameObject go)
		{
		}

		private GameObject GetIconForMaterial(BlendMaterialType material)
		{
			return null;
		}

		private Vector3 GetScaleForMaterial(BlendMaterialType material)
		{
			return default(Vector3);
		}

		private void OnDestroy()
		{
		}
	}
}
