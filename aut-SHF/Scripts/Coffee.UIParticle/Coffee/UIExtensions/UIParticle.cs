using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	public class UIParticle : MaskableGraphic
	{
		public enum MeshSharing
		{
			None = 0,
			Auto = 1,
			Primary = 2,
			PrimarySimulator = 3,
			Reprica = 4
		}

		[CompilerGenerated]
		private sealed class _003Cget_materials_003Ed__45 : IEnumerable<Material>, IEnumerable, IEnumerator<Material>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Material _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public UIParticle _003C_003E4__this;

			private int _003Ci_003E5__2;

			Material IEnumerator<Material>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003Cget_materials_003Ed__45(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Material> IEnumerable<Material>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[HideInInspector]
		[SerializeField]
		internal bool m_IsTrail;

		[Tooltip("Particle effect scale")]
		[SerializeField]
		private Vector3 m_Scale3D;

		[Tooltip("Animatable material properties. If you want to change the material properties of the ParticleSystem in Animation, enable it.")]
		[SerializeField]
		internal AnimatableProperty[] m_AnimatableProperties;

		[Tooltip("Particles")]
		[SerializeField]
		private List<ParticleSystem> m_Particles;

		[Tooltip("Mesh sharing.None: disable mesh sharing.\nAuto: automatically select Primary/Reprica.\nPrimary: provides particle simulation results to the same group.\nPrimary Simulator: Primary, but do not render the particle (simulation only).\nReprica: render simulation results provided by the primary.")]
		[SerializeField]
		private MeshSharing m_MeshSharing;

		[Tooltip("Mesh sharing group ID. If non-zero is specified, particle simulation results are shared within the group.")]
		[SerializeField]
		private int m_GroupId;

		[SerializeField]
		private int m_GroupMaxId;

		[SerializeField]
		[Tooltip("The particles will be emitted at the ParticleSystem position.\nMove the UIParticle/ParticleSystem to move the particle.")]
		private bool m_AbsoluteMode;

		private List<UIParticleRenderer> m_Renderers;

		private DrivenRectTransformTracker _tracker;

		private Camera _orthoCamera;

		private int _groupId;

		public override bool raycastTarget
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MeshSharing meshSharing
		{
			get
			{
				return default(MeshSharing);
			}
			set
			{
			}
		}

		public int groupId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int groupMaxId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool absoluteMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal bool useMeshSharing => false;

		internal bool isPrimary => false;

		internal bool canSimulate => false;

		internal bool canRender => false;

		public float scale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 scale3D
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public List<ParticleSystem> particles => null;

		public IEnumerable<Material> materials
		{
			[IteratorStateMachine(typeof(_003Cget_materials_003Ed__45))]
			get
			{
				return null;
			}
		}

		public override Material materialForRendering => null;

		public bool isPaused { get; internal set; }

		public void Play()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		public void Stop()
		{
		}

		public void Clear()
		{
		}

		public void SetParticleSystemInstance(GameObject instance)
		{
		}

		public void SetParticleSystemInstance(GameObject instance, bool destroyOldParticles)
		{
		}

		public void SetParticleSystemPrefab(GameObject prefab)
		{
		}

		public void RefreshParticles()
		{
		}

		private void RefreshParticles(GameObject root)
		{
		}

		public void RefreshParticles(List<ParticleSystem> particles)
		{
		}

		internal void UpdateTransformScale()
		{
		}

		internal void UpdateRenderers()
		{
		}

		internal void UpdateParticleCount()
		{
		}

		protected override void OnEnable()
		{
		}

		internal void ResetGroupId()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void UpdateMaterial()
		{
		}

		protected override void UpdateGeometry()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		private void UpdateRendererMaterial()
		{
		}

		internal UIParticleRenderer GetRenderer(int index)
		{
			return null;
		}

		private Camera GetBakeCamera()
		{
			return null;
		}
	}
}
