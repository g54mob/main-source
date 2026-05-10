using UnityEngine;

public class TeamComponent : MonoBehaviour
{
	public delegate void OnTeamChanged(int newTeam, int oldTeam);

	[SerializeField]
	private int team;

	public int Team
	{
		get
		{
			return team;
		}
		set
		{
			int oldTeam = team;
			team = value;
			UpdateTeamColor();
			this.onTeamChanged?.Invoke(team, oldTeam);
		}
	}

	public event OnTeamChanged onTeamChanged;

	private void Start()
	{
		UpdateTeamColor();
	}

	public bool IsEnemy(TeamComponent other)
	{
		if (Team != other.Team && !IsNeutral())
		{
			return !other.IsNeutral();
		}
		return false;
	}

	public bool IsAlly(TeamComponent other)
	{
		if (Team == other.Team && !IsNeutral())
		{
			return !other.IsNeutral();
		}
		return false;
	}

	public bool IsNeutral()
	{
		return team < 0;
	}

	private void UpdateTeamColor()
	{
		Color value = (IsNeutral() ? Color.gray : (team switch
		{
			0 => Color.blue, 
			1 => Color.red, 
			_ => Color.black, 
		}));
		foreach (Renderer meshRenderer in FunctionLibrary.GetMeshRenderers(base.gameObject))
		{
			meshRenderer.material.SetColor("_TeamColor", value);
		}
	}
}
