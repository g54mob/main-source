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

		private static readonly List<UIParticleRenderer> s_Renderers;

		private static readonly Vector3[] s_Corners;

		private ParticleSystemRenderer _renderer;

		private ParticleSystem _particleSystem;

		private int _prevParticleCount;

		private UIParticle _parent;

		private int _index;

		private bool _isTrail;

		private Material _modifiedMaterial;

		private Vector3 _prevScale;

		private Vector3 _prevPsPos;

		private Vector2Int _prevScreenSize;

		private bool _delay;

		private bool _prewarm;

		private Material _currentMaterialForRendering;

		private Bounds _lastBounds;

		public override Texture mainTexture => null;

		public override bool raycastTarget => false;

		private Rect rootCanvasRect => default(Rect);

		public static UIParticleRenderer AddRenderer(UIParticle parent, int index)
		{
			return null;
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		public void Clear(int index = -1)
		{
		}

		public void Set(UIParticle parent, ParticleSystem particleSystem, bool isTrail)
		{
		}

		public void UpdateMesh(Camera bakeCamera)
		{
		}

		internal void UpdateParticleCount()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
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
