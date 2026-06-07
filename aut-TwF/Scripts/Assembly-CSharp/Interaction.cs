using System.Collections.Generic;

public struct Interaction
{
	public enum EInteractionState
	{
		Undefined = 0,
		Processing = 1,
		Complete = 2,
		Failed = 3,
		Canceled = 4
	}

	public InteractiveAgent involvedAgent;

	public Interactive interactive;

	public InteractionOption option;

	public Dictionary<string, string> optionalData;

	public EInteractionState state;

	public Interaction(InteractiveAgent involvedAgent, Interactive interactive, InteractionOption option, Dictionary<string, string> optionalData = null)
	{
		this.involvedAgent = involvedAgent;
		this.interactive = interactive;
		this.option = option;
		state = EInteractionState.Undefined;
		if (optionalData != null)
		{
			this.optionalData = optionalData;
		}
		else
		{
			this.optionalData = new Dictionary<string, string>();
		}
	}

	public Interaction(Interaction interaction)
	{
		involvedAgent = interaction.involvedAgent;
		interactive = interaction.interactive;
		option = interaction.option;
		optionalData = interaction.optionalData;
		state = EInteractionState.Undefined;
	}
}
