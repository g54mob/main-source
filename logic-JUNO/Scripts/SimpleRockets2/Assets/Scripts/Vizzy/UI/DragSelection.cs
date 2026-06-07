using System.Collections.Generic;
using Assets.Scripts.Vizzy.UI.Elements;
using ModApi.Audio;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI
{
	public class DragSelection
	{
		private class PotentialConnection
		{
			public float DistanceSquared { get; set; }

			public ConnectionPoint Source { get; set; }

			public ConnectionPoint Target { get; set; }

			public override bool Equals(object obj)
			{
				if (obj is PotentialConnection potentialConnection && Source == potentialConnection.Source && Target == potentialConnection.Target)
				{
					return true;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public override string ToString()
			{
				return $"{Source?.Block.name}.{Source?.ConnectionPointType} -> {Target?.Block.name}.{Target?.ConnectionPointType}, Distance: {Mathf.Sqrt(DistanceSquared)}";
			}
		}

		public const float MaxConnectionDistance = 50f;

		public const float MaxConnectionDistanceSquared = 2500f;

		private PotentialConnection _bestConnection;

		private float _lastSoundTime;

		private IVizzyUI _vizzyUI;

		public List<BlockElementScript> Blocks { get; private set; } = new List<BlockElementScript>();

		public List<ConnectionPoint> SourceConnectionPoints { get; private set; } = new List<ConnectionPoint>();

		public List<ConnectionPoint> TargetConnectionPoints { get; private set; } = new List<ConnectionPoint>();

		public Transform Transform { get; private set; }

		private PotentialConnection BestConnection
		{
			get
			{
				return _bestConnection;
			}
			set
			{
				if (_bestConnection != null)
				{
					_bestConnection.Target.Block.PreviewConnection(null);
				}
				if (value != null && (_bestConnection == null || !_bestConnection.Equals(value)) && Time.unscaledTime - _lastSoundTime > 0.1f)
				{
					_lastSoundTime = Time.unscaledTime;
					_vizzyUI.PlaySound(AudioLibrary.Vizzy.SuggestConnection);
				}
				_bestConnection = value;
				if (_bestConnection != null)
				{
					_bestConnection.Target.Block.PreviewConnection(_bestConnection.Target);
					_vizzyUI.DisplayConnectionHint(_bestConnection.Source.Position, _bestConnection.Target.Position);
				}
				else
				{
					_vizzyUI.HideConnectionHint();
				}
			}
		}

		public DragSelection(IVizzyUI vizzyUI, Vector2 position, IEnumerable<BlockElementScript> blocks)
		{
			GameObject gameObject = new GameObject("DragSelection");
			_vizzyUI = vizzyUI;
			Transform = gameObject.transform;
			Transform.SetParent(vizzyUI.DragTransform, worldPositionStays: false);
			Transform.position = position;
			_lastSoundTime = Time.unscaledTime;
			foreach (BlockElementScript block in blocks)
			{
				Blocks.Add(block);
				block.transform.SetParent(Transform, worldPositionStays: true);
				foreach (ConnectionPoint connectionPoint in block.ConnectionPoints)
				{
					if (connectionPoint.CanSeek)
					{
						SourceConnectionPoints.Add(connectionPoint);
					}
				}
			}
			IdentifyTargetConnectionPoints();
		}

		public bool EndSelection()
		{
			bool result = false;
			foreach (BlockElementScript block in Blocks)
			{
				block.transform.SetParent(_vizzyUI.ProgramTransform, worldPositionStays: true);
			}
			if (BestConnection != null)
			{
				BestConnection.Source.Block.OnUserConnected(BestConnection.Source, BestConnection.Target);
				BestConnection = null;
				result = true;
			}
			Object.Destroy(Transform.gameObject);
			return result;
		}

		public void Update(Vector2 position, bool overTrashcan)
		{
			Transform.position = position;
			if (!overTrashcan)
			{
				PotentialConnection potentialConnection = null;
				foreach (ConnectionPoint sourceConnectionPoint in SourceConnectionPoints)
				{
					foreach (ConnectionPoint targetConnectionPoint in TargetConnectionPoints)
					{
						if (ConnectionPoint.IsCompatible(sourceConnectionPoint, targetConnectionPoint))
						{
							float sqrMagnitude = (sourceConnectionPoint.Position - targetConnectionPoint.Position).sqrMagnitude;
							if (sqrMagnitude < 2500f && (potentialConnection == null || sqrMagnitude < potentialConnection.DistanceSquared))
							{
								potentialConnection = new PotentialConnection
								{
									Source = sourceConnectionPoint,
									Target = targetConnectionPoint,
									DistanceSquared = sqrMagnitude
								};
							}
						}
					}
				}
				BestConnection = potentialConnection;
			}
			else
			{
				BestConnection = null;
			}
		}

		private void IdentifyTargetConnectionPoints()
		{
			BlockElementScript[] componentsInChildren = _vizzyUI.ProgramTransform.GetComponentsInChildren<BlockElementScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				foreach (ConnectionPoint connectionPoint in componentsInChildren[i].ConnectionPoints)
				{
					foreach (ConnectionPoint sourceConnectionPoint in SourceConnectionPoints)
					{
						if (connectionPoint.CanReceive && ConnectionPoint.IsCompatible(sourceConnectionPoint, connectionPoint))
						{
							TargetConnectionPoints.Add(connectionPoint);
						}
					}
				}
			}
		}
	}
}
