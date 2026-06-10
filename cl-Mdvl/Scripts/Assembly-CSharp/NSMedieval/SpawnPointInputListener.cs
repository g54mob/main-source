using NSEipix.Base;
using NSMedieval.Components;
using UnityEngine;

namespace NSMedieval
{
	public class SpawnPointInputListener : InputListener
	{
		private Vector3 dragStartPos;

		private bool dragSelectionStarted;

		public SpawnPointInputListener()
			: base(InputListenerType.SpawnPoint)
		{
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			if (MonoSingleton<SpawnPointManager>.Instance.Active && !GuiInputListener.IsMouseOverGui())
			{
				dragStartPos = Vector3.zero;
				dragSelectionStarted = false;
				if (button != 0)
				{
					MonoSingleton<SpawnPointManager>.Instance.CancelSelection();
					return;
				}
				dragStartPos = position;
				MonoSingleton<SpawnPointManager>.Instance.OnMouseButtonDown(position);
			}
		}

		public override void Update()
		{
			if (MonoSingleton<SpawnPointManager>.Instance.Active)
			{
				MonoSingleton<SpawnPointManager>.Instance.OnPositionUpdate(Input.mousePosition);
			}
		}

		public override void BlockedUpdate()
		{
			if (MonoSingleton<SpawnPointManager>.Instance.Active)
			{
				MonoSingleton<SpawnPointManager>.Instance.OnPositionUpdate(Input.mousePosition);
			}
		}

		public override void MouseButtonTick(int button, Vector3 position)
		{
			if (MonoSingleton<SpawnPointManager>.Instance.Active && !GuiInputListener.IsMouseOverGui() && button == 0)
			{
				if (!dragSelectionStarted && dragStartPos != Vector3.zero && Vector3.Distance(dragStartPos, position) > 9f)
				{
					dragSelectionStarted = true;
					MonoSingleton<SpawnPointManager>.Instance.OnDragStart(dragStartPos);
				}
				else if (dragSelectionStarted)
				{
					MonoSingleton<SpawnPointManager>.Instance.OnDragTick(position);
				}
			}
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			if (!MonoSingleton<SpawnPointManager>.Instance.Active || GuiInputListener.IsMouseOverGui())
			{
				return;
			}
			if (button != 0)
			{
				MonoSingleton<SpawnPointManager>.Instance.CancelSelection();
				return;
			}
			MonoSingleton<SpawnPointManager>.Instance.OnMouseButtonUp(position);
			if (dragSelectionStarted)
			{
				dragSelectionStarted = false;
				dragStartPos = Vector3.zero;
			}
		}

		public override bool IsStopEventPropagation()
		{
			return MonoSingleton<SpawnPointManager>.Instance.Dragging;
		}
	}
}
