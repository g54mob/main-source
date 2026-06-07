namespace Gh.Tk
{
	public interface IActorColliderInteraction
	{
		void OnActorEnteredCollider(Actor actor);

		void OnActorLeftCollider(Actor actor);
	}
}
