using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class TechTreeDisplay : MonoBehaviour
	{
		public float Repulsion = 3000f;

		public float Spacing = 70f;

		public float Stiffness = 10f;

		public float Damping = 0.9f;

		public int Iterations = 1;

		public UpgradeNode NodePrefab;

		[HideInInspector]
		public UpgradeNode SelectedNode;

		public GameObject LoadingDisplay;

		private Dictionary<string, UpgradeNode> _nodes = new Dictionary<string, UpgradeNode>();

		private readonly Dictionary<UpgradeNode, Vector2> _velocity = new Dictionary<UpgradeNode, Vector2>();

		private readonly Dictionary<UpgradeNode, Vector2> _position = new Dictionary<UpgradeNode, Vector2>();

		public void Start()
		{
			StartCoroutine(Setup());
		}

		public IEnumerator Setup()
		{
			LoadingDisplay.SetActive(true);
			List<WeaponAttributeUpgrade> allUpgrades = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<WeaponAttributeUpgrade>();
			_nodes = new Dictionary<string, UpgradeNode>();
			Stopwatch watch = new Stopwatch();
			watch.Start();
			foreach (WeaponAttributeUpgrade item in allUpgrades)
			{
				UpgradeNode upgradeNode = Object.Instantiate(NodePrefab, base.transform);
				upgradeNode.Init(item, this);
				upgradeNode.name = item.Name.GetTranslation();
				upgradeNode.transform.localPosition = Random.insideUnitCircle.normalized;
				_nodes.Add(item.UniqueId, upgradeNode);
				if (watch.ElapsedMilliseconds > 16)
				{
					yield return true;
					watch.Reset();
				}
			}
			foreach (WeaponAttributeUpgrade item2 in allUpgrades)
			{
				UpgradeNode upgradeNode2 = _nodes[item2.UniqueId];
				foreach (WeaponAttributeUpgrade parentUpgrade in item2.ParentUpgrades)
				{
					if (parentUpgrade == null)
					{
						UnityEngine.Debug.LogError(upgradeNode2.Upgrade.Name);
						continue;
					}
					UpgradeNode upgradeNode3 = _nodes[parentUpgrade.UniqueId];
					upgradeNode2.AddParent(upgradeNode3);
					upgradeNode3.AddChild(upgradeNode2);
				}
			}
			watch.Reset();
			IEnumerator iterator = UpdateGraph();
			int i = 0;
			while (iterator.MoveNext())
			{
				i++;
				if (watch.ElapsedMilliseconds > 16)
				{
					yield return true;
					watch.Reset();
				}
				if (i > Iterations)
				{
					break;
				}
			}
			LoadingDisplay.SetActive(false);
			StartCoroutine(UpdateGraph());
		}

		public IEnumerator UpdateGraph()
		{
			while (true)
			{
				foreach (UpgradeNode value in _nodes.Values)
				{
					if (!_velocity.ContainsKey(value))
					{
						_velocity.Add(value, Vector2.zero);
					}
					Vector3 localPosition = value.transform.localPosition;
					if (!_position.ContainsKey(value))
					{
						_position.Add(value, new Vector2(localPosition.x, localPosition.y));
					}
				}
				foreach (UpgradeNode value2 in _nodes.Values)
				{
					Vector2 zero = Vector2.zero;
					foreach (UpgradeNode value3 in _nodes.Values)
					{
						if (!(value3 == value2))
						{
							Vector2 vector = _position[value2] - _position[value3];
							zero += vector.normalized * Repulsion / Mathf.Pow(vector.magnitude, 2f);
						}
					}
					foreach (UpgradeNode parentNode in value2.ParentNodes)
					{
						Vector2 vector2 = _position[parentNode] - _position[value2];
						float num = Spacing - vector2.magnitude;
						zero += vector2.normalized * (Stiffness * num * -0.5f);
					}
					foreach (UpgradeNode childrenNode in value2.ChildrenNodes)
					{
						Vector2 vector3 = _position[childrenNode] - _position[value2];
						float num2 = Spacing - vector3.magnitude;
						zero += vector3.normalized * (Stiffness * num2 * -0.5f);
					}
					zero -= ((Vector2)base.transform.localPosition - _position[value2]).normalized;
					_velocity[value2] = (_velocity[value2] + zero * 0.1f) * Damping;
					if (_velocity[value2].magnitude > 10f)
					{
						_velocity[value2] = _velocity[value2].normalized * 10f;
					}
					_position[value2] += _velocity[value2];
					if (value2.IsPressed)
					{
						_position[value2] = value2.transform.localPosition;
					}
					if (value2.ParentNodes.Count <= 0)
					{
						_position[value2] = Vector3.zero;
					}
					value2.transform.localPosition = _position[value2];
				}
				yield return true;
			}
		}

		public void UpdateCompatibility(WeaponPreset selectedWeapon)
		{
			foreach (KeyValuePair<string, UpgradeNode> node in _nodes)
			{
				node.Value.UpgradeCompatibility(selectedWeapon);
			}
		}

		public void ChangeAll(bool unlock)
		{
			foreach (KeyValuePair<string, UpgradeNode> node in _nodes)
			{
				node.Value.Upgrade.ChangeLockStatus(unlock);
			}
		}
	}
}
