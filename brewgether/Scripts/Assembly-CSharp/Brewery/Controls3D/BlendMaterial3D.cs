using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class BlendMaterial3D : MonoBehaviour
	{
		[Header("Configuration")]
		[SerializeField]
		private BlendMaterialType materialType;

		[Header("References")]
		[Tooltip("Button that adds this material to the blend slots.")]
		[SerializeField]
		private Button3D addButton;

		[Header("Visual")]
		[Tooltip("Optional icon/visual that represents this material.")]
		[SerializeField]
		private GameObject materialIcon;

		public BlendMaterialType MaterialType => default(BlendMaterialType);

		public event Action<BlendMaterial3D> OnAddPressed
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

		private void OnDestroy()
		{
		}

		private void HandleAddPressed()
		{
		}

		public void SetVisualState(bool enabled)
		{
		}

		public void SetLocked(bool locked)
		{
		}
	}
}
