using System.Collections.Generic;

public class SSParticleStatic : StonescriptObject
{
	public SSParticleStatic()
		: base("Particle")
	{
		DeclareFunction(Clear);
	}

	protected object Clear(List<object> parameters, InvocationContext ctx)
	{
		GameStates.Singleton.gameParticleLayer.RecycleAllParticles();
		return null;
	}
}
