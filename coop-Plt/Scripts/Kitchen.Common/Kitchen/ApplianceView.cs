using System;
using KitchenData;
using MessagePack;
using UnityEngine;
using UnityEngine.VFX;

namespace Kitchen
{
	[Serializable]
	public class ApplianceView : UpdatableObjectView<ApplianceView.ViewData>
	{
		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int ApplianceID;

			[Key(1)]
			public bool Broken;

			[Key(2)]
			public bool InteractTarget;

			[Key(3)]
			public int DrawUsing;

			[Key(4)]
			public bool MarkedForDeletion;

			[Key(5)]
			public bool IsOnFire;

			public bool IsChangedFrom(ViewData other)
			{
				if (other.ApplianceID == ApplianceID && other.Broken == Broken && other.InteractTarget == InteractTarget && other.DrawUsing == DrawUsing && other.IsOnFire == IsOnFire)
				{
					return other.MarkedForDeletion != MarkedForDeletion;
				}
				return true;
			}
		}

		[Header("Configuration")]
		[SerializeField]
		private bool SkipRotationAnimation;

		[Header("References")]
		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private Transform Container;

		[SerializeField]
		private GameObject BrokenIcon;

		[SerializeField]
		private GameObject DeletionIcon;

		[SerializeField]
		private VisualEffect Fire;

		[SerializeField]
		private Shader HighlightableShader;

		[Header("State")]
		private bool IsBeingDestroyed;

		private MeshRenderer[] MeshRenderers;

		private ExitAnimation ExitAnimation;

		private GameObject Prefab;

		private IViewModifier[] ViewModifiers = Array.Empty<IViewModifier>();

		private ViewData Data;

		public override void Initialise()
		{
			base.Initialise();
			MeshRenderers = GetComponentsInChildren<MeshRenderer>();
		}

		public override void Remove()
		{
			if (base.gameObject == null)
			{
				return;
			}
			if ((bool)HeldItemPosition)
			{
				foreach (Transform item in HeldItemPosition.transform)
				{
					item.GetComponent<IObjectView>()?.ParentDestroyed();
				}
			}
			if (Animator != null)
			{
				Animator.Play(ExitAnimation.ToString());
				Animator.Update(0f);
			}
			else
			{
				UnityEngine.Object.Destroy(base.GameObject);
			}
		}

		public override void SetPosition(UpdateViewPositionData pos)
		{
			if (!SkipRotationAnimation && pos.Rotation.IsChangedFrom(base.transform.localRotation) && Animator.GetCurrentAnimatorStateInfo(0).IsName("Neutral"))
			{
				Animator.Play("Rotate");
				Animator.Update(0f);
			}
			base.SetPosition(pos);
		}

		private void Update()
		{
			if (Animator.GetCurrentAnimatorStateInfo(0).IsName("DestroyObject"))
			{
				base.Remove();
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (Data.InteractTarget != data.InteractTarget)
			{
				MeshRenderer[] meshRenderers = MeshRenderers;
				foreach (MeshRenderer meshRenderer in meshRenderers)
				{
					if (meshRenderer == null)
					{
						continue;
					}
					Material[] materials = meshRenderer.materials;
					foreach (Material material in materials)
					{
						if (material.shader == HighlightableShader)
						{
							RegisterDisposable(material);
							material.SetFloat("_Highlight", Data.InteractTarget ? 1 : 0);
						}
					}
				}
			}
			if (Data.IsOnFire != data.IsOnFire)
			{
				if (Data.IsOnFire && !Fire.gameObject.activeSelf)
				{
					Fire.gameObject.SetActive(value: true);
				}
				Fire.SetFloat("Active", Data.IsOnFire ? 1 : 0);
			}
			if (Data.ApplianceID != data.ApplianceID)
			{
				if (Prefab != null)
				{
					UnityEngine.Object.Destroy(Prefab);
				}
				if (!GameData.Main.TryGet<Appliance>(Data.ApplianceID, out var output, warn_if_fail: true))
				{
					return;
				}
				SkipRotationAnimation = output.SkipRotationAnimation;
				GameObject prefab = GameData.Main.GetPrefab(Data.ApplianceID);
				if (Data.DrawUsing != 0 && GameData.Main.TryGet<Decor>(Data.DrawUsing, out var output2))
				{
					prefab = GameData.Main.DecoratorPrefabView.GetPrefab(output2);
				}
				Prefab = UnityEngine.Object.Instantiate(prefab, Container);
				Prefab.transform.localPosition = Vector3.zero;
				Prefab.transform.localScale = Vector3.one;
				Prefab.transform.localRotation = Quaternion.identity;
				HoldPointContainer component = Prefab.GetComponent<HoldPointContainer>();
				if (component != null)
				{
					HeldItemPosition = component.HoldPoint;
				}
				MeshRenderers = Prefab.GetComponentsInChildren<MeshRenderer>();
				PurgeComponentCache();
				ViewModifiers = Prefab.GetComponentsInChildren<IViewModifier>(includeInactive: true);
				ExitAnimation = output.ExitAnimation;
				Animator.Play(output.EntryAnimation.ToString());
				Animator.Update(0f);
			}
			IViewModifier[] viewModifiers = ViewModifiers;
			for (int i = 0; i < viewModifiers.Length; i++)
			{
				viewModifiers[i].UpdateState(view_data);
			}
			if (Data.Broken != data.Broken)
			{
				BrokenIcon.SetActive(Data.Broken);
			}
			if (Data.MarkedForDeletion != data.MarkedForDeletion)
			{
				DeletionIcon.SetActive(Data.MarkedForDeletion);
			}
		}
	}
}
