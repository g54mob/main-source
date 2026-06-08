using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public abstract class Element : MonoBehaviour, IModule
	{
		public enum ThemeColour
		{
			Default = 0,
			Cancel = 1
		}

		[SerializeField]
		[Header("References")]
		private Animator GenericAnimator;

		[Header("State")]
		protected bool HasFocus;

		private HashSet<string> AnimationParameters = new HashSet<string>();

		protected bool _IsSelectable = true;

		protected static Dictionary<ThemeColour, Color> Colours = new Dictionary<ThemeColour, Color>
		{
			{
				ThemeColour.Default,
				new Color(0.37f, 0.56f, 0.91f)
			},
			{
				ThemeColour.Cancel,
				new Color(0.5f, 0.11f, 0.1f)
			}
		};

		protected MemoryManagerHandle MemoryManagerHandle => this;

		public Vector2 Position
		{
			get
			{
				return base.transform.localPosition;
			}
			set
			{
				base.transform.localPosition = value;
			}
		}

		public abstract Bounds BoundingBox { get; }

		public virtual bool IsSelectable
		{
			get
			{
				if (_IsSelectable)
				{
					return base.gameObject.activeInHierarchy;
				}
				return false;
			}
		}

		private void Start()
		{
			UpdateParameters();
			SetAnimBool("HasFocus", HasFocus);
		}

		private void OnDestroy()
		{
			MemoryManagerHandle.Dispose();
		}

		public virtual void Initialise()
		{
		}

		protected void SetAnimBool(string name, bool value)
		{
			UpdateParameters(force: true);
			if (HasParameter(name))
			{
				GenericAnimator.SetBool(name, value);
			}
		}

		protected void SetAnimInt(string name, int value)
		{
			UpdateParameters(force: true);
			if (HasParameter(name))
			{
				GenericAnimator.SetInteger(name, value);
			}
		}

		protected void SetAnimFloat(string name, float value)
		{
			UpdateParameters(force: true);
			if (HasParameter(name))
			{
				GenericAnimator.SetFloat(name, value);
			}
		}

		protected bool HasParameter(string p_name)
		{
			if (GenericAnimator == null)
			{
				return false;
			}
			return AnimationParameters.Contains(p_name);
		}

		private void UpdateParameters(bool force = false)
		{
			AnimationParameters.Clear();
			if (!(GenericAnimator == null) && GenericAnimator.isInitialized)
			{
				AnimatorControllerParameter[] parameters = GenericAnimator.parameters;
				foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
				{
					AnimationParameters.Add(animatorControllerParameter.name);
				}
			}
		}

		public virtual void SetSelectable(bool selectable, bool keep_full_alpha = false)
		{
			_IsSelectable = selectable;
		}

		public virtual void GainFocus()
		{
			HasFocus = true;
			UpdateFocus();
		}

		public virtual void LoseFocus()
		{
			HasFocus = false;
			UpdateFocus();
		}

		public virtual void UpdateFocus()
		{
			SetAnimBool("HasFocus", HasFocus);
		}

		public virtual bool HandleInteraction(InputState state)
		{
			return false;
		}

		public virtual void Destroy()
		{
			try
			{
				if (base.gameObject != null)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			catch
			{
			}
		}

		public void SetVisible(bool visible)
		{
			base.gameObject.SetActive(visible);
		}

		protected T Add<T>() where T : Element
		{
			return ModuleDirectory.Add<T>(base.transform);
		}

		private void OnDrawGizmosSelected()
		{
			try
			{
				Transform transform = ((base.transform.parent != null) ? base.transform.parent : base.transform);
				Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
				Gizmos.DrawWireCube(transform.TransformPoint(BoundingBox.center), transform.TransformVector(BoundingBox.size));
			}
			catch (Exception)
			{
				Gizmos.DrawIcon(base.transform.position, "Gizmo Error.png", allowScaling: true);
			}
		}
	}
}
