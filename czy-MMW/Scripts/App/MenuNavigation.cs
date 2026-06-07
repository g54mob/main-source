using Factory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class MenuNavigation
{
	public interface IObserver
	{
		void OnMoveCursorWithNullFocus();

		void OnMoveCursor(Selectable currentFocus, MoveDirection direction);
	}

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MenuNavigation");

	[Dependency]
	protected IScope _scope;

	protected Selectable _activeFocus;

	protected Vector2 _accumulatedMovement = Vector2.zero;

	public float menuNavigationSwipeThreshold = 0.15f;

	public static readonly Vector2[] MoveDirectionToVectorDirection = new Vector2[4]
	{
		Vector2.left,
		Vector2.up,
		Vector2.right,
		Vector2.down
	};

	[Serialize(false, null)]
	private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

	protected ObserverList<IObserver> Observers => _observers;

	public virtual PlayerAction CreateNavigateUpAction(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateMove(playerActionGroup, scope, time, Vector2.up);
	}

	public virtual PlayerAction CreateNavigateDownAction(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateMove(playerActionGroup, scope, time, Vector2.down);
	}

	public virtual PlayerAction CreateNavigateLeftAction(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateMove(playerActionGroup, scope, time, Vector2.left);
	}

	public virtual PlayerAction CreateNavigateRightAction(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateMove(playerActionGroup, scope, time, Vector2.right);
	}

	public virtual PlayerAction CreateNavigateAccept(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateActivateSelected(playerActionGroup, scope, time);
	}

	public virtual PlayerAction CreateNavigateBack(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateBackSelected(playerActionGroup, scope, time);
	}

	public virtual PlayerAction CreateNavigatePageLeft(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateChangePageSelected(playerActionGroup, scope, time, Vector2.left);
	}

	public virtual PlayerAction CreateNavigatePageRight(PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		return MenuNavigationAction.CreateChangePageSelected(playerActionGroup, scope, time, Vector2.right);
	}

	public PlayerAction CreateNavigateInDirection(int inputAxisX, int inputAxisY, PlayerActionGroup playerActionGroup, IScope scope, float time)
	{
		InputState inputState = scope.Get<InputState>();
		Vector2 direction = new Vector2(inputState.GetAxis(inputAxisX), inputState.GetAxis(inputAxisY));
		return MenuNavigationAction.CreateMove(playerActionGroup, scope, time, direction);
	}

	public virtual void AccumulateMove(Vector2 direction)
	{
		_accumulatedMovement += direction;
		Log.Info("Accumulated movement {0}", _accumulatedMovement);
		if (_accumulatedMovement.sqrMagnitude > menuNavigationSwipeThreshold * menuNavigationSwipeThreshold && MoveCursor(_accumulatedMovement.normalized))
		{
			_accumulatedMovement = Vector2.zero;
		}
	}

	public virtual bool MoveCursor(Vector2 direction)
	{
		ObserverList<IObserver>.Enumerator enumerator;
		if (_activeFocus == null || !_activeFocus.gameObject.activeInHierarchy)
		{
			Log.Info("No Active Focus to move from!");
			enumerator = Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnMoveCursorWithNullFocus();
			}
			_scope.Get<InputState>().CurrentInputTypeRequiresFocus = true;
			return true;
		}
		Selectable selectable = null;
		MoveDirection moveDirection = VectorDirectionToMoveDirection(direction);
		enumerator = Observers.GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.OnMoveCursor(_activeFocus, moveDirection);
		}
		if (_activeFocus.navigation.mode == Navigation.Mode.Explicit)
		{
			selectable = GetSelectableForDirection(_activeFocus, moveDirection);
			if (selectable == null)
			{
				selectable = _activeFocus;
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					if (!(selectable != null))
					{
						break;
					}
					if (selectable.gameObject.activeInHierarchy)
					{
						break;
					}
					selectable = GetSelectableForDirection(selectable, moveDirection);
				}
				if (selectable == null)
				{
					Log.Warn("We tried 5 times to find a new focus going {0} from {1} and didn't find anything active! May need to reorder the explicit navigation on this screen.", moveDirection, _activeFocus);
				}
			}
		}
		else
		{
			selectable = GetSelectableForDirection(_activeFocus, moveDirection);
		}
		int num;
		if (selectable != null)
		{
			num = ((selectable != _activeFocus) ? 1 : 0);
			if (num != 0)
			{
				SetNewFocus(selectable);
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	private Selectable GetSelectableForDirection(Selectable selectable, MoveDirection moveDirection)
	{
		return moveDirection switch
		{
			MoveDirection.Left => selectable.FindSelectableOnLeft(), 
			MoveDirection.Up => selectable.FindSelectableOnUp(), 
			MoveDirection.Right => selectable.FindSelectableOnRight(), 
			MoveDirection.Down => selectable.FindSelectableOnDown(), 
			_ => selectable, 
		};
	}

	public static MoveDirection VectorDirectionToMoveDirection(Vector2 direction)
	{
		int result = -1;
		float num = float.MaxValue;
		for (int i = 0; i < MoveDirectionToVectorDirection.Length; i++)
		{
			float num2 = Vector2.Distance(MoveDirectionToVectorDirection[i].normalized, direction.normalized);
			if (num2 < num)
			{
				result = i;
				num = num2;
			}
		}
		return (MoveDirection)result;
	}

	public virtual void SetNewFocus(Selectable newFocus)
	{
		if (newFocus != null)
		{
			Log.Info("Setting new focus: {0}", newFocus.name);
			_activeFocus = newFocus;
			EventSystem.current.SetSelectedGameObject(_activeFocus.gameObject);
		}
		else
		{
			ClearFocus();
		}
	}

	public virtual void ClearFocus(bool allowAutomaticFocus = true)
	{
		Log.Info("Clearing focus.");
		_activeFocus = null;
		EventSystem.current?.SetSelectedGameObject(null);
		if (!allowAutomaticFocus)
		{
			_scope.Get<InputState>().CurrentInputTypeRequiresFocus = false;
		}
	}

	public virtual void ReleaseUIFocus()
	{
		_activeFocus = null;
		EventSystem.current?.SetSelectedGameObject(null);
	}

	public virtual Selectable GetCurrentFocus()
	{
		return EventSystem.current?.currentSelectedGameObject?.GetComponent<Selectable>();
	}

	public abstract bool ActivateSelected();

	public abstract void BackActivated();

	public abstract void PageSelected(Vector2 direction);

	public void Subscribe(IObserver observer)
	{
		_observers.Subscribe(observer);
	}

	public bool Unsubscribe(IObserver observer)
	{
		return _observers.Unsubscribe(observer);
	}
}
