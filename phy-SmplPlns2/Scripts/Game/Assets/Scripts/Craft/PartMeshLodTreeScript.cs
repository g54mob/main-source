using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class PartMeshLodTreeScript : MonoBehaviour
	{
		private static List<float> _allDistances = new List<float>(1024);

		private List<PartMeshLodTreeScript> _children;

		[SerializeField]
		private float _cullDistance;

		private float _cullScale = 1f;

		[SerializeField]
		private bool _enabledSelf = true;

		[SerializeField]
		private bool _ignoreLocalCulling;

		private int _lastFov = -1;

		private float _lastMinimumScreenSize;

		private bool _localPlayerCraft;

		[SerializeField]
		private int _lod = -1;

		[SerializeField]
		private List<float> _lods = new List<float>(5);

		[SerializeField]
		private List<MeshRenderer> _meshRenderers;

		[SerializeField]
		private List<int> _numRenderersAtLod = new List<int>();

		[SerializeField]
		private PartMeshLodTreeScript _parent;

		private PartScript _part;

		[SerializeField]
		private float _treeSize = -1f;

		public PartMeshLodTreeScript Parent => _parent;

		public float TreeSize
		{
			get
			{
				if (_treeSize < 0f)
				{
					CalculateTreeBounds();
				}
				return _treeSize;
			}
		}

		public bool Visible => _enabledSelf;

		public static void CreateTreeForBodyScript(BodyScript body, bool localPlayerCraft)
		{
			PartMeshLodTreeScript partMeshLodTreeScript = body.gameObject.AddComponent<PartMeshLodTreeScript>();
			partMeshLodTreeScript._localPlayerCraft = localPlayerCraft;
			bool ignoreLocalCulling = body.PartGroups.Count == 1 && body.PartGroups[0].Parts.Count < 5;
			foreach (PartGroupScript partGroup in body.PartGroups)
			{
				PartMeshLodTreeScript partMeshLodTreeScript2 = partGroup.gameObject.AddComponent<PartMeshLodTreeScript>();
				partMeshLodTreeScript2.SetParent(partMeshLodTreeScript);
				partMeshLodTreeScript2._ignoreLocalCulling = ignoreLocalCulling;
				if (partMeshLodTreeScript2.TryGetComponent<MeshRenderer>(out var component))
				{
					partMeshLodTreeScript2._meshRenderers = new List<MeshRenderer> { component };
				}
				foreach (PartScript part in partGroup.Parts)
				{
					MeshRenderer[] componentsInChildren = part.GetComponentsInChildren<MeshRenderer>();
					if (componentsInChildren.Length == 0)
					{
						continue;
					}
					PartMeshLodTreeScript partMeshLodTreeScript3 = part.gameObject.AddComponent<PartMeshLodTreeScript>();
					partMeshLodTreeScript3._part = part;
					partMeshLodTreeScript3._ignoreLocalCulling = ignoreLocalCulling;
					partMeshLodTreeScript3._cullScale = part.Part.PartType.CullScale;
					if (componentsInChildren.Length != 0)
					{
						partMeshLodTreeScript3._meshRenderers = new List<MeshRenderer>();
						MeshRenderer[] array = componentsInChildren;
						foreach (MeshRenderer meshRenderer in array)
						{
							if (meshRenderer.enabled)
							{
								partMeshLodTreeScript3._meshRenderers.Add(meshRenderer);
							}
						}
					}
					List<MeshRenderer> meshRenderers = partMeshLodTreeScript3._meshRenderers;
					if (meshRenderers != null && meshRenderers.Count > 0)
					{
						partMeshLodTreeScript3.SetParent(partMeshLodTreeScript2);
					}
				}
			}
			body.LodTree = partMeshLodTreeScript;
		}

		public void SetParent(PartMeshLodTreeScript parent)
		{
			if (_parent != null)
			{
				_parent._children.Remove(this);
				_parent._treeSize = -1f;
				_parent._lastFov = -1;
			}
			_parent = parent;
			if (_parent != null)
			{
				if (parent._children == null)
				{
					parent._children = new List<PartMeshLodTreeScript>();
				}
				parent._children.Add(this);
				_parent._treeSize = -1f;
				_parent._lastFov = -1;
			}
			else
			{
				_lastFov = -1;
				_treeSize = -1f;
			}
		}

		public void UpdateFromCamera(Camera camera, bool isFirstPerson, float minimumScreenSize)
		{
			if (_lastFov != (int)camera.fieldOfView || _lastMinimumScreenSize != minimumScreenSize)
			{
				_lastFov = (int)camera.fieldOfView;
				_lastMinimumScreenSize = minimumScreenSize;
				float distancePerUnitSize = 1f / Mathf.Tan(minimumScreenSize * 0.5f * camera.fieldOfView * (MathF.PI / 180f) * 0.5f);
				CalculateCullDistance(distancePerUnitSize);
				CalculateDynamicLodDistances();
				_lod = -1;
			}
			float distance = Vector3.Distance(base.transform.position, camera.transform.position);
			if (isFirstPerson && _localPlayerCraft)
			{
				distance = 0f;
			}
			float lodDistance;
			int lod = GetLod(distance, out lodDistance);
			if (_lod != lod)
			{
				_lod = lod;
				UpdateTree(lodDistance);
			}
		}

		protected virtual void OnDestroy()
		{
			EnableTree();
			SetParent(null);
		}

		private static int CountCulledRenderers(PartMeshLodTreeScript tree, float distance)
		{
			int num = 0;
			if (tree._cullDistance < distance)
			{
				num += tree._meshRenderers?.Count ?? 0;
			}
			if (tree._children != null)
			{
				foreach (PartMeshLodTreeScript child in tree._children)
				{
					num += CountCulledRenderers(child, distance);
				}
			}
			return num;
		}

		private void AddLodDistance(float distance)
		{
			if (_lods.Count > 0)
			{
				float num = _lods.LastOrDefault();
				distance = Mathf.Max(distance, num * 2f);
				_lods.Add(Mathf.Min(distance, _cullDistance + 1f));
			}
			else
			{
				_lods.Add(distance);
			}
		}

		private void CalculateCullDistance(float distancePerUnitSize)
		{
			_cullDistance = TreeSize * 0.5f * distancePerUnitSize;
			if (_children == null)
			{
				return;
			}
			foreach (PartMeshLodTreeScript child in _children)
			{
				child.CalculateCullDistance(distancePerUnitSize);
			}
		}

		private void CalculateDynamicLodDistances()
		{
			_allDistances.Clear();
			CollectCullDistances(_allDistances);
			_allDistances.Sort();
			_lods.Clear();
			int count = _allDistances.Count;
			float distance = 10f;
			if (_allDistances.Count < 10)
			{
				AddLodDistance(distance);
			}
			else if (_allDistances.Count < 25)
			{
				AddLodDistance(distance);
				AddLodDistance(_allDistances[(int)((float)count * 0.5f)]);
			}
			else if (_allDistances.Count < 50)
			{
				AddLodDistance(distance);
				AddLodDistance(_allDistances[(int)((float)count * 0.33f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.66f)]);
			}
			else if (_allDistances.Count < 100)
			{
				AddLodDistance(distance);
				AddLodDistance(_allDistances[(int)((float)count * 0.25f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.5f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.75f)]);
			}
			else
			{
				AddLodDistance(distance);
				AddLodDistance(_allDistances[(int)((float)count * 0.2f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.4f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.6f)]);
				AddLodDistance(_allDistances[(int)((float)count * 0.8f)]);
			}
			_lods.Add(_cullDistance + 1f);
		}

		[ContextMenu("Calculate Bounds")]
		private Bounds CalculateTreeBounds()
		{
			Bounds result = new Bounds(base.transform.position, Vector2.zero);
			if (_meshRenderers != null)
			{
				foreach (MeshRenderer meshRenderer in _meshRenderers)
				{
					result.Encapsulate(meshRenderer.bounds);
				}
			}
			if (_children != null)
			{
				foreach (PartMeshLodTreeScript child in _children)
				{
					result.Encapsulate(child.CalculateTreeBounds());
				}
			}
			_treeSize = result.size.magnitude * _cullScale;
			return result;
		}

		private void CollectCullDistances(List<float> distances)
		{
			distances.Add(_cullDistance);
			if (_children == null)
			{
				return;
			}
			foreach (PartMeshLodTreeScript child in _children)
			{
				child.CollectCullDistances(distances);
			}
		}

		private void DisableTree()
		{
			if (!_enabledSelf)
			{
				return;
			}
			EnableSelf(enable: false);
			if (_children == null)
			{
				return;
			}
			foreach (PartMeshLodTreeScript child in _children)
			{
				child.DisableTree();
			}
		}

		private void EnableSelf(bool enable)
		{
			if (_enabledSelf == enable)
			{
				return;
			}
			_enabledSelf = enable;
			if (_part != null)
			{
				_part.Culled = !enable;
			}
			if (_meshRenderers == null)
			{
				return;
			}
			foreach (MeshRenderer meshRenderer in _meshRenderers)
			{
				meshRenderer.enabled = enable;
			}
		}

		private void EnableTree()
		{
			EnableSelf(enable: true);
			if (_children == null)
			{
				return;
			}
			foreach (PartMeshLodTreeScript child in _children)
			{
				child.EnableTree();
			}
		}

		private int GetLod(float distance, out float lodDistance)
		{
			int num = _lods.Count;
			for (int i = 0; i < _lods.Count; i++)
			{
				if (distance < _lods[i])
				{
					num = i;
					break;
				}
			}
			lodDistance = ((num == 0) ? 0f : _lods[num - 1]);
			return num;
		}

		private void UpdateTree(float distance)
		{
			if (_ignoreLocalCulling || distance < _cullDistance)
			{
				EnableSelf(enable: true);
				if (_children == null)
				{
					return;
				}
				{
					foreach (PartMeshLodTreeScript child in _children)
					{
						child.UpdateTree(distance);
					}
					return;
				}
			}
			DisableTree();
		}
	}
}
