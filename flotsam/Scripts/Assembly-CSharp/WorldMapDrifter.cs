using PajamaLlama.Math;
using UnityEngine;

public class WorldMapDrifter : MonoBehaviour
{
	private Agent _agent;

	public void Initialize(Agent agent)
	{
		_agent = agent;
		_agent.OnBoatBoard.AddListener(Enable);
		_agent.OnBoatLeave.AddListener(Disable);
		if (_agent.IsCaptain)
		{
			Enable();
		}
		else
		{
			Disable();
		}
	}

	private void OnDestroy()
	{
		_agent.OnBoatBoard.RemoveListener(Enable);
		_agent.OnBoatLeave.RemoveListener(Disable);
	}

	private void Update()
	{
		base.transform.position = _agent.transform.position.SetY(0f);
	}

	private void Enable()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Disable()
	{
		base.gameObject.SetActive(value: false);
	}
}
