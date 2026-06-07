using System;
using System.Xml.Linq;
using Assets.Scripts.Flight.Sim;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class CraftTracker
	{
		private int _contractNumber;

		private ICraftScript _craftScript;

		private bool _failedToFindPayload;

		private IFlightContext _flightContext;

		private bool _generateTrackingId;

		private IPartScript _part;

		public ICraftNode CraftNode { get; private set; }

		public string CraftTrackingId { get; private set; }

		public bool IsDestroyed { get; private set; }

		public bool IsTrackingCraft
		{
			get
			{
				if (CraftTrackingId != null)
				{
					return CraftNode != null;
				}
				return false;
			}
		}

		public bool IsTrackingPayload => PartTrackingId != null;

		public Action<ICraftNode, bool> OnSubscribeCraftNodeEvents { get; set; }

		public Action<ICraftScript, bool> OnSubscribeCraftScriptEvents { get; set; }

		public IPartScript Part => _part;

		public string PartTrackingId { get; private set; }

		public string PayloadId { get; }

		public CraftTracker(int contractNumber, XElement xml, string payloadId = null)
		{
			_contractNumber = contractNumber;
			PayloadId = payloadId;
			CraftTrackingId = xml?.Attribute("craftTrackingId")?.Value;
			PartTrackingId = xml?.Attribute("partTrackingId")?.Value;
			IsDestroyed = xml?.GetBoolAttribute("destroyed") ?? false;
		}

		public void OnFlightEnd()
		{
			if (IsTrackingCraft)
			{
				CraftTrackingId = CraftNode.ContractTrackingId;
			}
			SetCraftNode(null);
		}

		public void OnFlightStart(IFlightContext flightContext, bool generateCraftTrackingId)
		{
			_flightContext = flightContext;
			_generateTrackingId = generateCraftTrackingId;
			StartTracking();
		}

		public void ResetStatus()
		{
			StopTracking();
			IsDestroyed = false;
			if (_flightContext != null)
			{
				OnFlightStart(_flightContext, _generateTrackingId);
			}
		}

		public void SaveXml(XElement xml)
		{
			xml.SetAttributeValue("craftTrackingId", CraftTrackingId);
			xml.SetAttributeValue("partTrackingId", PartTrackingId);
			xml.SetAttributeValue("destroyed", IsDestroyed);
		}

		public void SetCraftNode(ICraftNode craftNode)
		{
			if (craftNode == CraftNode)
			{
				return;
			}
			if (CraftNode != null)
			{
				SetCraftScript(null);
				CraftNode.LoadedIntoGameView -= OnCraftNodeLoadedIntoGameView;
				CraftNode.UnloadingFromGameView -= OnCraftNodeUnloadingFromGameView;
				CraftNode.Destroyed -= OnCraftNodeDestroyed;
				CraftNode.CraftNodeMerged -= OnCraftNodeMerged;
				OnSubscribeCraftNodeEvents?.Invoke(CraftNode, arg2: false);
			}
			CraftNode = craftNode;
			if (CraftNode == null)
			{
				return;
			}
			CraftNode.LoadedIntoGameView += OnCraftNodeLoadedIntoGameView;
			CraftNode.UnloadingFromGameView += OnCraftNodeUnloadingFromGameView;
			CraftNode.Destroyed += OnCraftNodeDestroyed;
			CraftNode.CraftNodeMerged += OnCraftNodeMerged;
			OnSubscribeCraftNodeEvents?.Invoke(CraftNode, arg2: true);
			if (CraftNode.CraftScript != null)
			{
				SetCraftScript(CraftNode.CraftScript);
			}
			if (_generateTrackingId)
			{
				if (string.IsNullOrEmpty(CraftNode.ContractTrackingId))
				{
					CraftNode.ContractTrackingId = Guid.NewGuid().ToString();
				}
				CraftTrackingId = CraftNode.ContractTrackingId;
			}
		}

		public void StartTracking()
		{
			if (CraftTrackingId != null)
			{
				CraftNode craftNode = _flightContext.FlightState.GetCraftNode((CraftNode n) => n.ContractTrackingId == CraftTrackingId);
				SetCraftNode(craftNode);
				if (CraftNode == null && !_generateTrackingId)
				{
					IsDestroyed = true;
				}
			}
			else if (_generateTrackingId)
			{
				SetCraftNode(_flightContext.CraftNode);
			}
			ICraftNode craftNode2 = CraftNode;
			if (craftNode2 != null && craftNode2.IsDestroyed)
			{
				IsDestroyed = true;
				StopTracking();
			}
		}

		public void StopTracking()
		{
			if (PartTrackingId != null)
			{
				PartTrackingId = null;
			}
			if (_part != null)
			{
				_part.Data.Payload.PayloadTrackingId = null;
				_part = null;
			}
			if (_generateTrackingId)
			{
				CraftTrackingId = null;
			}
			SetCraftNode(null);
		}

		public void Update()
		{
			if (_failedToFindPayload)
			{
				_failedToFindPayload = false;
				StopTracking();
			}
			else if (!IsDestroyed)
			{
				IPartScript part = _part;
				if (part != null && part.Data.IsDestroyed)
				{
					IsDestroyed = true;
					StopTracking();
				}
			}
		}

		private void FindPayload(ICraftScript craftScript)
		{
			_part = craftScript.GetPayloadPart(PayloadId, _contractNumber, PartTrackingId);
			if (_part != null && _generateTrackingId && string.IsNullOrEmpty(_part.Data.Payload.PayloadTrackingId))
			{
				IPayload payload = _part.Data.Payload;
				string payloadTrackingId = (PartTrackingId = Guid.NewGuid().ToString());
				payload.PayloadTrackingId = payloadTrackingId;
			}
		}

		private void OnCraftNodeDestroyed(INode node)
		{
			IsDestroyed = true;
			StopTracking();
		}

		private void OnCraftNodeLoadedIntoGameView(IGameViewObject source)
		{
			SetCraftScript(CraftNode.CraftScript);
		}

		private void OnCraftNodeMerged(ICraftNode targetCraftNode, ICraftNode sourceCraftNode)
		{
			if (CraftNode == sourceCraftNode)
			{
				SetCraftNode(targetCraftNode);
			}
		}

		private void OnCraftNodeUnloadingFromGameView(IGameViewObject source)
		{
			SetCraftScript(null);
		}

		private void OnCraftSplit(ICraftScript craftScript)
		{
			if (_part != null)
			{
				IPartScript part = _part;
				SetCraftNode(null);
				_generateTrackingId = !string.IsNullOrEmpty(PartTrackingId);
				SetCraftNode(part?.CraftScript?.CraftNode);
			}
			else
			{
				Debug.Log("Craft split, but could not track new craft node. Part was null");
			}
		}

		private void SetCraftScript(ICraftScript craftScript)
		{
			_part = null;
			if (_craftScript != null)
			{
				if (!string.IsNullOrWhiteSpace(PayloadId))
				{
					_craftScript.CraftSplit -= OnCraftSplit;
				}
				OnSubscribeCraftScriptEvents?.Invoke(_craftScript, arg2: false);
			}
			_craftScript = craftScript;
			if (_craftScript == null)
			{
				return;
			}
			if (!string.IsNullOrWhiteSpace(PayloadId))
			{
				_craftScript.CraftSplit += OnCraftSplit;
				FindPayload(_craftScript);
				if (!string.IsNullOrEmpty(PayloadId) && _part == null && _flightContext.IsNewLaunch && PartTrackingId == null)
				{
					_failedToFindPayload = true;
				}
			}
			OnSubscribeCraftScriptEvents?.Invoke(_craftScript, arg2: true);
		}
	}
}
