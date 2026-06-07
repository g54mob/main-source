using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class PatchBayWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement bayContainer;

		private VisualElement[] sourceSockets;

		private VisualElement[] sinkSockets;

		private VisualElement[] connectionLines;

		private VisualElement cooldownOverlay;

		private int[] connections;

		private int selectedSource;

		public ControlType WidgetType => default(ControlType);

		public float Value => 0f;

		public bool IsActive { get; private set; }

		public int ControlIndex { get; }

		public int ActiveConnectionCount => 0;

		public event Action<IControlWidget, float> OnValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IControlWidget> OnActionTriggered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<int, int> OnConnectionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public PatchBayWidget(ControlDefinition def, int controlIndex)
		{
		}

		public void BuildUI(VisualElement container)
		{
		}

		public void SetActive(bool active)
		{
		}

		public void SetCooldown(float remainingSeconds, float totalSeconds)
		{
		}

		public void SetTarget(float targetMin, float targetMax)
		{
		}

		public void SetMeterValues(float[] allMeterValues)
		{
		}

		public void Tick(float deltaTime)
		{
		}

		public void OnPointerDown(PointerDownEvent evt)
		{
		}

		public void OnPointerMove(PointerMoveEvent evt)
		{
		}

		public void OnPointerUp(PointerUpEvent evt)
		{
		}

		public void SetConnections(int[] newConnections)
		{
		}

		public void Dispose()
		{
		}

		private VisualElement BuildMeterDots()
		{
			return null;
		}

		private void HandleSourceClick(int sourceIdx)
		{
		}

		private void HandleSinkClick(int sinkIdx)
		{
		}

		private void ClearSelection()
		{
		}

		private void HighlightSource(int idx, bool highlight)
		{
		}

		private void UpdateConnectionVisuals()
		{
		}
	}
}
