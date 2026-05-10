using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class SurfaceObject : CTSBehaviour
	{
		[Inject(false)]
		private MeshRenderer _meshRenderer;

		private Vector4 _currentCutCoord;

		private Vector2 _currentCutSize;

		private Material _mat;

		private static readonly int _maskCoords = Shader.PropertyToID("_maskCoords");

		private static readonly int _maskSize = Shader.PropertyToID("_maskSize");

		private static Dictionary<int, Queue<Material>> _matPool = new Dictionary<int, Queue<Material>>();

		private static Dictionary<Material, int> _usedMats = new Dictionary<Material, int>();

		private bool _visible = true;

		private void OnDestroy()
		{
			_matPool.Clear();
			_usedMats.Clear();
		}

		public void ChangeVisibility(bool visible)
		{
			if (visible != _meshRenderer.enabled)
			{
				_meshRenderer.enabled = visible;
			}
			_visible = visible;
		}

		public void ChangeMaterial(Material material)
		{
			_meshRenderer.enabled = material != null;
			if (material == null)
			{
				return;
			}
			int instanceID = material.GetInstanceID();
			if (_mat != null && _usedMats.TryGetValue(_mat, out var value))
			{
				if (value == instanceID)
				{
					return;
				}
				_matPool[value].Enqueue(_mat);
				_usedMats.Remove(_mat);
				_mat = null;
			}
			_matPool.EnsureKeyExists(instanceID);
			if (_matPool[instanceID].Count > 0)
			{
				_mat = _matPool[instanceID].Dequeue();
			}
			else
			{
				_mat = new Material(material);
			}
			_usedMats[_mat] = instanceID;
			_meshRenderer.sharedMaterial = _mat;
			CutQuad(_currentCutCoord, _currentCutSize);
		}

		private void CutQuad(Vector4 coord, Vector2 size)
		{
			_currentCutCoord = coord;
			_currentCutSize = size;
			if (!(_mat == null))
			{
				_mat.SetVector(_maskCoords, coord);
				_mat.SetVector(_maskSize, new Vector3(size.x, size.y, 1f));
			}
		}

		public void CutQuad(WallCutter cutter)
		{
			Vector4 getCutterPosition = cutter.GetCutterPosition;
			if (base.transform.forward != cutter.transform.forward)
			{
				getCutterPosition.z = 0f - getCutterPosition.z;
			}
			CutQuad(getCutterPosition, cutter.GetCutterSize);
		}

		public void ResetCutter()
		{
			CutQuad(Vector2.zero, Vector2.zero);
		}
	}
}
