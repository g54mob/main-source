using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu(null)]
	internal class UIParticleRenderer : MaskableGraphic
	{
		private static readonly CombineInstance[] s_CombineInstances;

		private static readonly List<Material> s_Materials;

		private static MaterialPropertyBlock s_Mpb;

		private static readonly Vector3[] s_Corners;

		private bool _delay;

		private int _index;

		private bool _isPrevStored;

		private bool _isTrail;

		private Bounds _lastBounds;

		private Material _materialForRendering;

		private Material _modifiedMaterial;

		private UIParticle _parent;

		private ParticleSystem _particleSystem;

		private float _prevCanvasScale;

		private Vector3 _prevPsPos;

		private Vector3 _prevScale;

		private Vector2Int _prevScreenSize;

		private bool _preWarm;

		private ParticleSystemRenderer _renderer;

		public override Texture mainTexture => null;

		public override bool raycastTarget => false;

		private Rect rootCanvasRect => default(Rect);

		public override Material materialForRendering => null;

		public void Reset(int index = -1)
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public static UIParticleRenderer AddRenderer(UIParticle parent, int index)
		{
			return null;
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		public void Set(UIParticle parent, ParticleSystem ps, bool isTrail)
		{
		}

		public void UpdateMesh(Camera bakeCamera)
		{
		}

		public override void SetMaterialDirty()
		{
		}

		protected override void UpdateGeometry()
		{
		}

		public override void Cull(Rect clipRect, bool validRect)
		{
		}

		private Vector3 GetWorldScale()
		{
			return default(Vector3);
		}

		private Matrix4x4 GetWorldMatrix(Vector3 psPos, Vector3 scale)
		{
			return default(Matrix4x4);
		}

		private void ResolveResolutionChange(Vector3 psPos, Vector3 scale)
		{
		}

		private void Simulate(Vector3 scale, bool paused)
		{
		}

		private void UpdateMaterialProperties()
		{
		}
	}
}
