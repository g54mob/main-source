using System;
using System.Collections.Generic;
using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Flight.UI;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain
{
	public class ChainNodeManager : IChainNodeOptions, IChainNodeList
	{
		private const int MaxConsecutiveEncounters = 20;

		private MapCraft _craft;

		private InfoPanel _infoPanel;

		private float? _lastManeuverNodeUpdateTime;

		private INavSphere _navSphere;

		private LinkedList<IChainableOrbit> _orbitChainNodes;

		private LinkedList<ManeuverNodeScript> _orphanedNodes;

		private float? _sendPulseStartTime;

		public bool AllowEncounterNodeCreation => ConsecutiveEncounterNodesAtEndOfList < 20;

		public LinkedList<IChainableOrbit> ChainNodes => _orbitChainNodes;

		public int ConsecutiveEncounterNodesAtEndOfList { get; private set; }

		public SoiEncounterNodeScript FirstEncounter { get; private set; }

		public ManeuverNodeScript FirstIncompleteManeuverNode { get; private set; }

		public ManeuverNodeScript FirstManeuverNode { get; private set; }

		public IChainableOrbit FirstNode => _orbitChainNodes.First.Value;

		public IChainableOrbit FirstNonCraftNode { get; private set; }

		public IChainableOrbit LastNode => _orbitChainNodes.Last?.Value;

		public bool ShowNodeInfo { get; private set; }

		public double? TimeToNextNode
		{
			get
			{
				LinkedListNode<IChainableOrbit> next = ChainNodes.First.Next;
				if (next != null)
				{
					double time = ChainNodes.First.Value.OrbitInfo.OrbitNode.Orbit.Time;
					return next.Value.OrbitInfo.OrbitNode.Orbit.Time - time;
				}
				return null;
			}
		}

		public event NodeListChangedDelegate NodeAdded;

		public event NodeListChangedDelegate NodeListChanged;

		public event NodeListChangedDelegate RemovingNode;

		public ChainNodeManager(ICraftContext craftContext, MapCraft craft)
		{
			Initialize(craftContext, craft);
		}

		public LinkedListNode<IChainableOrbit> AddAfter(LinkedListNode<IChainableOrbit> addAfter, Func<LinkedListNode<IChainableOrbit>, IChainableOrbit> creationMethod, NodeListChangeCategory category)
		{
			LinkedListNode<IChainableOrbit> linkedListNode = _orbitChainNodes.AddAfter(addAfter, (IChainableOrbit)null);
			linkedListNode.Value = creationMethod(linkedListNode);
			OnNodeAdded(linkedListNode, category);
			linkedListNode.Value.OrbitInfo.OnNewNextNode();
			addAfter.Value.OrbitInfo.OnNewNextNode();
			return linkedListNode;
		}

		public void DestroyNodes()
		{
			RemoveAfter<OrbitChainNodeScript>(ChainNodes.First, consecutiveOccurrencesOnly: false, NodeListChangeCategory.Normal);
			DestroyOrphanedNodes();
		}

		public void DestroyOrphanedNodes()
		{
			foreach (ManeuverNodeScript orphanedNode in _orphanedNodes)
			{
				DestroyNode(orphanedNode.ListNode);
			}
			_orphanedNodes.Clear();
		}

		public void Dispose()
		{
			if (_infoPanel != null)
			{
				UnityEngine.Object.Destroy(_infoPanel.gameObject);
			}
			this.NodeAdded = null;
			this.NodeListChanged = null;
			this.RemovingNode = null;
		}

		public void OnAfterCameraPositioned(bool mapViewVisible)
		{
			for (LinkedListNode<IChainableOrbit> linkedListNode = _orbitChainNodes?.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value.OnAfterCameraPositioned();
			}
			if (mapViewVisible && _craft.SupportsOrbitLinePulses)
			{
				if (_lastManeuverNodeUpdateTime.HasValue && (double)(Time.time - _lastManeuverNodeUpdateTime.Value) > 0.5)
				{
					_lastManeuverNodeUpdateTime = null;
					StartPulse();
				}
				UpdateOrbitLineHighlight();
			}
			UpdateCraftManeuverNodeDirection();
		}

		public void OnBeforeCameraPositioned(bool mapViewVisible)
		{
			MonitorOrphanedNodes();
			if (mapViewVisible && _craft is MapPlayerCraft)
			{
				RegisterInfoPanel();
			}
		}

		public void PerformValidityChecks()
		{
			for (LinkedListNode<IChainableOrbit> linkedListNode = _orbitChainNodes?.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value.PerformValidityCheck();
			}
		}

		public void Remove(LinkedListNode<IChainableOrbit> orbitLineNode, bool deleteChildren, bool destroy, NodeListChangeCategory category)
		{
			LinkedListNode<IChainableOrbit> previousNode = orbitLineNode.Previous;
			_orbitChainNodes.Remove(orbitLineNode, deleteChildren, delegate(LinkedListNode<IChainableOrbit> x)
			{
				OnRemovingNode(x, category);
				if (destroy)
				{
					DestroyNode(x);
				}
			}, delegate
			{
				OnNodeRemoved(category);
				previousNode.Value.OrbitInfo.OnNewNextNode();
			});
		}

		public void RemoveAfter<T>(LinkedListNode<IChainableOrbit> orbitLineNode, bool consecutiveOccurrencesOnly, NodeListChangeCategory category) where T : IChainableOrbit
		{
			if (orbitLineNode.Next != null)
			{
				RemoveType<T>(orbitLineNode.Next, consecutiveOccurrencesOnly, category);
			}
		}

		public void RemoveType<T>(LinkedListNode<IChainableOrbit> startingNodeToDelete, bool consecutiveOccurrencesOnly, NodeListChangeCategory category) where T : IChainableOrbit
		{
			LinkedListNode<IChainableOrbit> next = startingNodeToDelete.Next;
			bool flag = startingNodeToDelete.Value is T;
			if (flag)
			{
				Remove(startingNodeToDelete, deleteChildren: false, destroy: true, category);
			}
			if (next != null && (flag || !consecutiveOccurrencesOnly))
			{
				RemoveType<T>(next, consecutiveOccurrencesOnly, category);
			}
		}

		public void SetOrphaned(ManeuverNodeScript maneuverNodeScript)
		{
			LinkedListNode<IChainableOrbit> previous = maneuverNodeScript.ListNode.Previous;
			for (LinkedListNode<IChainableOrbit> linkedListNode = maneuverNodeScript.ListNode; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value is ManeuverNodeScript)
				{
					OrphanManeuverNode(linkedListNode.Value as ManeuverNodeScript);
				}
			}
			RemoveAfter<IChainableOrbit>(previous, consecutiveOccurrencesOnly: false, NodeListChangeCategory.Orphan);
		}

		private void ActivateOrphaned(ManeuverNodeScript maneuverNodeScript, LinkedListNode<IChainableOrbit> previous)
		{
			AddAfter(previous, delegate(LinkedListNode<IChainableOrbit> x)
			{
				maneuverNodeScript.SetListNode(x);
				return maneuverNodeScript;
			}, NodeListChangeCategory.Orphan);
			maneuverNodeScript.SendPreviousNodeOrbitChanged(previous.Value.OrbitInfo.OrbitNode.Orbit);
			maneuverNodeScript.OnOrphanedStateChanged(orphaned: false);
		}

		private LinkedListNode<IChainableOrbit> AddFirst(IChainableOrbit chainableOrbit, NodeListChangeCategory category)
		{
			LinkedListNode<IChainableOrbit> linkedListNode = _orbitChainNodes.AddFirst(chainableOrbit);
			OnNodeAdded(linkedListNode, category);
			return linkedListNode;
		}

		private void DestroyNode(LinkedListNode<IChainableOrbit> node)
		{
			node.Value.OrbitInfo.DestroyOrbitLine();
		}

		private void DestroyNode(LinkedListNode<ManeuverNodeScript> node)
		{
			node.Value.OrbitInfo.DestroyOrbitLine();
		}

		private void Initialize(ICraftContext craftContext, MapCraft craft)
		{
			_craft = craft;
			IIocContainer ioc = craft.Ioc;
			ioc.Register((IChainNodeList)this, (IContext)craftContext);
			ioc.Register((IChainNodeOptions)this, (IContext)craftContext);
			_navSphere = FlightSceneScript.Instance.FlightSceneUI.NavSphere;
			_orbitChainNodes = new LinkedList<IChainableOrbit>();
			_orphanedNodes = new LinkedList<ManeuverNodeScript>();
			craft.SetListNode(AddFirst(craft, NodeListChangeCategory.Normal));
			Shader.SetGlobalFloat("_CraftOrbitLine_HighlightPos", 3f);
			if (craft is MapPlayerCraft)
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ioc.Resolve<IManeuverNodeAdjustments>(craftContext).ManeuverNodeAdjusted += OnManeuverNodeAdjusted;
				});
			}
		}

		private void MonitorOrphanedNodes()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num = realtimeSinceStartup - 30f;
			LinkedListNode<ManeuverNodeScript> linkedListNode = _orphanedNodes.First;
			while (linkedListNode != null)
			{
				LinkedListNode<ManeuverNodeScript> next = linkedListNode.Next;
				if ((linkedListNode.Value.OrphanedTime ?? realtimeSinceStartup) < num)
				{
					Debug.Log("Orphaned node expired: " + linkedListNode.Value.name);
					DestroyNode(linkedListNode);
					_orphanedNodes.Remove(linkedListNode);
				}
				else
				{
					for (LinkedListNode<IChainableOrbit> linkedListNode2 = ChainNodes.Last; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Previous)
					{
						if (linkedListNode.Value.IsSuitableForAdoption(linkedListNode2, linkedListNode2.Next))
						{
							ActivateOrphaned(linkedListNode.Value, linkedListNode2);
							_orphanedNodes.Remove(linkedListNode);
							break;
						}
					}
				}
				linkedListNode = next;
			}
		}

		private void OnManeuverNodeAdjusted(ManeuverNodeScript source)
		{
			_lastManeuverNodeUpdateTime = Time.time;
		}

		private void OnManeuverNodeExecutionCompleted(ManeuverNodeScript source)
		{
			UpdateFirstOfTypeReferences();
		}

		private void OnNodeAdded(LinkedListNode<IChainableOrbit> newNode, NodeListChangeCategory category)
		{
			OnNodeListChanged(newNode, category);
			this.NodeAdded?.Invoke(this, newNode, category);
		}

		private void OnNodeListChanged(LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
			UpdateFirstOfTypeReferences();
			int num = 0;
			LinkedListNode<IChainableOrbit> linkedListNode = _orbitChainNodes.Last;
			while (linkedListNode.Value is SoiEncounterNodeScript)
			{
				num++;
				linkedListNode = linkedListNode.Previous;
			}
			ConsecutiveEncounterNodesAtEndOfList = num;
			this.NodeListChanged?.Invoke(this, node, category);
		}

		private void OnNodeRemoved(NodeListChangeCategory category)
		{
			OnNodeListChanged(null, category);
		}

		private void OnRemovingNode(LinkedListNode<IChainableOrbit> nodeBeingRemoved, NodeListChangeCategory category)
		{
			this.RemovingNode?.Invoke(this, nodeBeingRemoved, category);
		}

		private void OrphanManeuverNode(ManeuverNodeScript maneuverNodeScript)
		{
			_orphanedNodes.AddLast(maneuverNodeScript);
			Remove(maneuverNodeScript.ListNode, deleteChildren: false, destroy: false, NodeListChangeCategory.Orphan);
			maneuverNodeScript.OnOrphanedStateChanged(orphaned: true);
		}

		private void QuickSaveNodeChain()
		{
			if (_craft is MapPlayerCraft)
			{
				(_craft as MapPlayerCraft).ChainNodeIO.QuickSaveNodeChain();
			}
			else
			{
				Debug.LogError("Only player craft can have their node chain saved.");
			}
		}

		private void RegisterInfoPanel()
		{
			if (_infoPanel == null)
			{
				_infoPanel = InfoPanel.Create<InfoPanel>("Chain Node Manager", delegate
				{
					Debug.Log("Chain node manager header clicked");
				});
				_infoPanel.AddDynamicText("time to next", () => $"{TimeToNextNode:0}s", rebuildUi: false);
				_infoPanel.AddToggleButton("show node info", initialValue: false, delegate(bool x)
				{
					ShowNodeInfo = x;
				}, rebuildUi: false);
				_infoPanel.AddButton("delete nodes", "delete nodes", delegate
				{
					DestroyNodes();
				}, rebuildUi: false);
				_infoPanel.AddButton("save nodes", "save nodes", delegate
				{
					QuickSaveNodeChain();
				}, rebuildUi: false);
				_infoPanel.AddButton("restore nodes", "restore nodes", delegate
				{
					RestoreNodeChainQuickSave();
				}, rebuildUi: false);
				_infoPanel.RebuildUi();
			}
		}

		private void RestoreNodeChainQuickSave()
		{
			if (_craft is MapPlayerCraft)
			{
				(_craft as MapPlayerCraft).ChainNodeIO.RestoreQuickSaveNodeChain();
			}
			else
			{
				Debug.LogError("Only player craft can have their node chain saved.");
			}
		}

		private void StartPulse()
		{
			_sendPulseStartTime = Time.time;
		}

		private void UpdateCraftManeuverNodeDirection()
		{
			if (_craft.SupportsManeuverNodes)
			{
				_navSphere.ManeuverNodeDirection = FirstManeuverNode?.GetDeltaVToCompleteManeuver();
				if (_navSphere.ManeuverNodeDirection.HasValue && _navSphere.ManeuverNodeDirection.Value.sqrMagnitude < 0.1)
				{
					_navSphere.ManeuverNodeDirection = null;
				}
			}
		}

		private void UpdateFirstOfTypeReferences()
		{
			if (FirstIncompleteManeuverNode != null)
			{
				FirstIncompleteManeuverNode.ExecutionCompleted -= OnManeuverNodeExecutionCompleted;
			}
			FirstIncompleteManeuverNode = null;
			FirstManeuverNode = null;
			FirstEncounter = null;
			FirstNonCraftNode = null;
			foreach (IChainableOrbit orbitChainNode in _orbitChainNodes)
			{
				if (FirstNonCraftNode == null && orbitChainNode != _craft)
				{
					FirstNonCraftNode = orbitChainNode;
				}
				if (FirstManeuverNode == null && orbitChainNode is ManeuverNodeScript)
				{
					FirstManeuverNode = orbitChainNode as ManeuverNodeScript;
				}
				if (FirstIncompleteManeuverNode == null && orbitChainNode is ManeuverNodeScript && !((ManeuverNodeScript)orbitChainNode).ExecutionComplete)
				{
					FirstIncompleteManeuverNode = (ManeuverNodeScript)orbitChainNode;
					FirstIncompleteManeuverNode.ExecutionCompleted += OnManeuverNodeExecutionCompleted;
				}
				if (FirstEncounter == null && orbitChainNode is SoiEncounterNodeScript)
				{
					FirstEncounter = orbitChainNode as SoiEncounterNodeScript;
				}
				if (FirstEncounter != null && FirstManeuverNode != null)
				{
					break;
				}
			}
		}

		private void UpdateOrbitLineHighlight()
		{
			if (_sendPulseStartTime.HasValue)
			{
				float num = Time.time - _sendPulseStartTime.Value;
				if (num <= 5f)
				{
					Shader.SetGlobalFloat("_CraftOrbitLine_HighlightPos", num / 5f);
					return;
				}
				Shader.SetGlobalFloat("_CraftOrbitLine_HighlightPos", 3f);
				_sendPulseStartTime = null;
			}
		}
	}
}
