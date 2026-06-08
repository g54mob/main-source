using System;
using Kitchen.Modules;
using KitchenData;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class GenericObjectView : MonoBehaviour, IObjectView
	{
		public Transform HeldItemPosition;

		protected Transform DefaultTransform;

		private ComponentCache _Cache;

		private IObjectView CurrentlyHeldItem;

		public GameObject GameObject => base.gameObject;

		private ComponentCache Cache => _Cache ?? (_Cache = new ComponentCache(base.transform));

		protected GlobalLocalisation Localisation => GameData.Main.GlobalLocalisation;

		protected float DeltaTime => Time.deltaTime;

		protected float RealDeltaTime => Time.unscaledDeltaTime;

		private MemoryManagerHandle MemoryManagerHandle => this;

		protected virtual Interpolator<Vector3> PositionInterpolator { get; } = new InstantInterpolator<Vector3>(default(Vector3Interpolator));

		protected virtual Interpolator<Quaternion> RotationInterpolator { get; } = new InstantInterpolator<Quaternion>(default(QuaternionInterpolator));

		public virtual void Initialise()
		{
			DefaultTransform = base.transform.parent;
		}

		protected virtual void OnDestroy()
		{
			DisposeDisposables();
		}

		public virtual void Remove()
		{
			try
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
				if (PlatformSettings.IsEditor)
				{
					UnityEngine.Object.DestroyImmediate(base.gameObject);
				}
				else
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			catch (Exception)
			{
			}
		}

		protected void DisposeDisposables()
		{
			MemoryManagerHandle.Dispose();
		}

		public T RegisterDisposable<T>(T d) where T : UnityEngine.Object
		{
			MemoryManagerHandle.Register(d, out var _);
			return d;
		}

		public virtual void SetHeldItem(IObjectView held_item, int storage_index, bool is_tool)
		{
			if (storage_index < 0 && held_item != CurrentlyHeldItem)
			{
				if ((MonoBehaviour)CurrentlyHeldItem != null && CurrentlyHeldItem.GameObject.transform.parent == HeldItemPosition)
				{
					CurrentlyHeldItem.ParentDestroyed();
				}
				held_item?.SetParent(HeldItemPosition);
				CurrentlyHeldItem = held_item;
			}
		}

		public virtual void ParentDestroyed()
		{
			SetParent(DefaultTransform, set_active: false);
			base.transform.localPosition = new Vector3(0f, -100f, 0f);
		}

		public virtual void SetParent(Transform new_parent, bool set_active = true)
		{
			Transform obj = base.transform;
			obj.parent = new_parent;
			obj.localPosition = Vector3.zero;
			obj.localRotation = Quaternion.identity;
			obj.localScale = Vector3.one;
			base.gameObject.SetActive(set_active && (bool)new_parent);
		}

		public virtual void SetPosition(UpdateViewPositionData pos)
		{
			bool force = pos.Force;
			PositionInterpolator.Report(pos.Position, pos.GameTime, force);
			RotationInterpolator.Report(pos.Rotation, pos.GameTime, force);
			UpdatePosition();
		}

		public virtual void PerformUpdate()
		{
			UpdatePosition();
		}

		protected virtual void UpdatePosition()
		{
			if (!(this == null))
			{
				Transform transform = base.transform;
				if (PositionInterpolator != null)
				{
					transform.localPosition = PositionInterpolator.GetUpdate(transform.localPosition);
				}
				if (RotationInterpolator != null)
				{
					transform.localRotation = RotationInterpolator.GetUpdate(transform.localRotation);
				}
			}
		}

		public virtual CPosition GetPosition()
		{
			if (this == null)
			{
				return new CPosition
				{
					Position = Vector3.zero,
					Rotation = Quaternion.identity
				};
			}
			Transform transform = base.transform;
			return new CPosition
			{
				Position = transform.localPosition,
				Rotation = transform.localRotation
			};
		}

		protected void PurgeComponentCache()
		{
			Cache.Clear();
		}

		public virtual T GetSubView<T>() where T : MonoBehaviour
		{
			return Cache.Get<T>();
		}

		protected Transform AddContainer(Vector3 v3 = default(Vector3))
		{
			Transform obj = new GameObject().transform;
			obj.parent = base.transform;
			obj.Reset();
			obj.localPosition = v3;
			return obj;
		}

		protected virtual T Add<T>(Transform t = null) where T : Element
		{
			return ModuleDirectory.Add<T>((t == null) ? base.transform : t);
		}
	}
}
