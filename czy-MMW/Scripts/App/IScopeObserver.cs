using Factory;

public interface IScopeObserver
{
	void OnScopeReleased(IScope scopeBeingReleased);
}
