using System.Collections.Generic;
using UnityEngine;

public class LocationLeaderboardScreen : DialogNineSlice
{
	private enum LeaderboardScreenState
	{
		Idle = 0,
		Submit = 1,
		Retry = 2,
		Loading = 3
	}

	public int entriesPerPage;

	public AsciiString title;

	public AsciiSprite loadingSpinner;

	public DialogButton closeButton;

	public DialogButton nextButton;

	public DialogButton prevButton;

	public LocationLeaderboardRow defaultRow;

	public LocationLeaderboardRow headerRow;

	public LocationLeaderboardRow emptyRow;

	public LeaderboardRetryDialog retryDialog;

	public LeaderboardSubmitDialog submitDialog;

	private LeaderboardScreenState currentLeaderboardScreenState;

	private List<LocationLeaderboardRow> rows = new List<LocationLeaderboardRow>();

	private LocationLeaderboardRow playerRow;

	private string leaderboardId;

	private int currentPage;

	private int totalPages = 999;

	private int startRank = 1;

	private LeaderboardEntry[] entries;

	private LeaderboardEntry playerEntry;

	private Dictionary<int, LeaderboardEntry> lastEntries = new Dictionary<int, LeaderboardEntry>();

	private bool isLastPage;

	private bool loadingEntries;

	private bool loadingPlayer;

	private bool loadingSubmit;

	private bool showMoneyHUD = true;

	private AsciiRenderProcedural.Clip myClip;

	public void ResetLeaderboardData()
	{
		currentPage = 0;
		startRank = 1;
		entries = null;
		playerEntry = null;
		for (int i = 0; i < entriesPerPage; i++)
		{
			rows[i].Reset();
		}
	}

	public void Show(string leaderboardId, string leaderboardName, int leaderboardDifficulty)
	{
		ResetLeaderboardData();
		this.leaderboardId = leaderboardId;
		title.SetValue(Te.xt(leaderboardName) + " " + leaderboardDifficulty + " ─ " + Te.xt("tid_leaderboard"));
		SetState(State.In);
		if (!LeaderboardController.singleton.HasSubmitted() && LeaderboardController.singleton.CanSubmit(leaderboardId))
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Submit);
		}
		else
		{
			RequestLeaderboardLocationGet();
			if (playerEntry == null && LeaderboardController.singleton.HasSubmitted())
			{
				RequestLeaderboardLocationPlayer();
			}
		}
		showMoneyHUD = false;
	}

	public void Hide()
	{
		SetLeaderboardScreenState(LeaderboardScreenState.Idle);
		SetState(State.Out);
		showMoneyHUD = true;
	}

	public void HideImmediatly()
	{
		SetLeaderboardScreenState(LeaderboardScreenState.Idle);
		base.SetState(State.Disabled);
		showMoneyHUD = true;
	}

	private void SetLeaderboardScreenState(LeaderboardScreenState newState)
	{
		switch (newState)
		{
		case LeaderboardScreenState.Submit:
			submitDialog.Show();
			break;
		case LeaderboardScreenState.Retry:
			retryDialog.Show();
			break;
		case LeaderboardScreenState.Loading:
			nextButton.enabled = false;
			prevButton.enabled = false;
			break;
		case LeaderboardScreenState.Idle:
			nextButton.enabled = false;
			prevButton.enabled = false;
			break;
		}
		currentLeaderboardScreenState = newState;
	}

	public void UpdateContents()
	{
		if (entries != null)
		{
			for (int i = 0; i < entriesPerPage; i++)
			{
				rows[i].Setup(entry: (i < entries.Length) ? entries[i] : null, rank: startRank + i);
			}
			if (playerEntry != null)
			{
				playerRow.Setup(playerEntry.rank, playerEntry);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		int num = (int)((float)Width * scaleX);
		int num2 = (int)((float)Height * scaleY);
		myClip.left = r.width - num >> 1;
		myClip.right = myClip.left;
		myClip.top = r.height - num2 >> 1;
		myClip.bottom = myClip.top;
		r.PushClip(myClip);
		title.Draw(r, offsetX, offsetY);
		int offsetX2 = offsetX - 18;
		int num3 = offsetY - 8;
		headerRow.Draw(r, offsetX2, num3 - 1);
		for (int i = 0; i < entriesPerPage; i++)
		{
			rows[i].Draw(r, offsetX2, num3 + i);
		}
		if (playerEntry != null && playerRow.rank >= startRank + entriesPerPage)
		{
			playerRow.Draw(r, offsetX2, num3 + entriesPerPage + 1);
		}
		if (!isLastPage)
		{
			nextButton.Draw(r, offsetX, offsetY);
		}
		if (currentPage > 0)
		{
			prevButton.Draw(r, offsetX, offsetY);
		}
		closeButton.Draw(r, offsetX, offsetY);
		if (currentLeaderboardScreenState == LeaderboardScreenState.Submit)
		{
			submitDialog.Draw(r, offsetX, offsetY);
		}
		else if (currentLeaderboardScreenState == LeaderboardScreenState.Retry)
		{
			retryDialog.Draw(r, offsetX, offsetY);
		}
		else if (currentLeaderboardScreenState == LeaderboardScreenState.Loading)
		{
			for (int j = 0; j < r.width; j++)
			{
				for (int k = 0; k < r.height; k++)
				{
					if (!r.IsClipped(j, k))
					{
						AsciiCellProcedural cell = r.GetCell(j, k, skipSafety: true);
						cell.foregroundColor = cell.GetForeground() * 0.65f;
						cell.backgroundColor = cell.GetBackground() * 0.65f;
					}
				}
			}
			loadingSpinner.Draw(r, offsetX, offsetY);
		}
		r.PopClip();
	}

	protected void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKey(KeyCode.Escape))
		{
			if (currentLeaderboardScreenState == LeaderboardScreenState.Idle || currentLeaderboardScreenState == LeaderboardScreenState.Loading)
			{
				Hide();
			}
		}
		else if (base.CurrentState == State.Idle && currentLeaderboardScreenState == LeaderboardScreenState.Idle)
		{
			if (nextButton.enabled && Binding.singleton.IsDown(Binding.Action.Down))
			{
				HandlePageNext(nextButton);
			}
			else if (prevButton.enabled && Binding.singleton.IsUp(Binding.Action.Up))
			{
				HandlePagePrev(prevButton);
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState != State.Idle)
		{
			return;
		}
		closeButton.UpdateTic();
		if (currentLeaderboardScreenState == LeaderboardScreenState.Idle)
		{
			prevButton.UpdateTic();
			nextButton.UpdateTic();
			emptyRow.UpdateTic();
			headerRow.UpdateTic();
			defaultRow.UpdateTic();
			for (int i = 0; i < rows.Count; i++)
			{
				rows[i].UpdateTic();
			}
		}
		else if (currentLeaderboardScreenState == LeaderboardScreenState.Submit)
		{
			submitDialog.UpdateTic();
			if (submitDialog.CurrentState == State.Disabled)
			{
				SetLeaderboardScreenState(LeaderboardScreenState.Idle);
			}
		}
		else if (currentLeaderboardScreenState == LeaderboardScreenState.Retry)
		{
			retryDialog.UpdateTic();
			if (retryDialog.CurrentState == State.Disabled)
			{
				SetLeaderboardScreenState(LeaderboardScreenState.Idle);
			}
		}
	}

	private bool HasFinishedLoading()
	{
		if (LeaderboardController.singleton.HasSubmitted())
		{
			if (entries != null && playerEntry != null && !loadingEntries && !loadingPlayer)
			{
				return !loadingSubmit;
			}
			return false;
		}
		if (entries != null && !loadingEntries)
		{
			return !loadingSubmit;
		}
		return false;
	}

	private void RequestLeaderboardLocationGet()
	{
		if (leaderboardId == null)
		{
			Utils.LogWarning("leaderboardId is null");
			return;
		}
		SetLeaderboardScreenState(LeaderboardScreenState.Loading);
		loadingEntries = true;
		int? lastScore = null;
		string lastPlayerId = null;
		if (currentPage > 0)
		{
			if (lastEntries.ContainsKey(currentPage - 1))
			{
				LeaderboardEntry leaderboardEntry = lastEntries[currentPage - 1];
				lastScore = leaderboardEntry.score;
				lastPlayerId = leaderboardEntry.playerId;
			}
			else
			{
				Utils.LogErrorIfEditor("Unable to get next page");
				currentPage = 0;
			}
		}
		LeaderboardController.singleton.LocationGet(leaderboardId, startRank, entriesPerPage, lastScore, lastPlayerId, LeaderboardLocationGetResponseDataCallback);
		Utils.LogIfEditor("LocationGet Called");
	}

	private void RequestLeaderboardLocationPlayer()
	{
		if (leaderboardId == null)
		{
			Utils.LogWarning("leaderboardId is null");
			return;
		}
		string playerId = LeaderboardController.singleton.GetPlayerId();
		if (playerId == null)
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Submit);
			return;
		}
		SetLeaderboardScreenState(LeaderboardScreenState.Loading);
		loadingPlayer = true;
		LeaderboardController.singleton.LocationPlayer(leaderboardId, playerId, LeaderboardLocationPlayerResponseDataCallback);
		Utils.LogIfEditor("LocationPlayer Called");
	}

	private void RequestLeaderboardLocationSubmit()
	{
		if (leaderboardId == null)
		{
			Utils.LogWarning("leaderboardId is null");
			return;
		}
		SetLeaderboardScreenState(LeaderboardScreenState.Loading);
		loadingSubmit = true;
		LeaderboardController.singleton.LocationSubmit(leaderboardId, LeaderboardEventSubmitResponseDataCallback);
		Utils.LogIfEditor("LocationSubmit Called with leaderboardId: " + leaderboardId);
	}

	private void LeaderboardLocationGetResponseDataCallback(LeaderboardEventGetResponseData data)
	{
		Utils.LogIfEditor("LocationGet -> Callback");
		if (currentLeaderboardScreenState != LeaderboardScreenState.Loading || data == null || data.entries == null)
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Retry);
			return;
		}
		entries = data.entries;
		startRank = 1 + entriesPerPage * currentPage;
		loadingEntries = false;
		if (data.entries.Length != 0)
		{
			LeaderboardEntry value = data.entries[data.entries.Length - 1];
			lastEntries[currentPage] = value;
		}
		isLastPage = data.isLastPage;
		if (HasFinishedLoading())
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Idle);
			UpdateContents();
		}
	}

	private void LeaderboardLocationPlayerResponseDataCallback(LeaderboardEventPlayerResponseData data)
	{
		Utils.LogIfEditor("LocationPlayer -> Callback");
		if (currentLeaderboardScreenState != LeaderboardScreenState.Loading || data == null)
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Retry);
			return;
		}
		playerEntry = data.entry;
		loadingPlayer = false;
		if (!data.success)
		{
			RequestLeaderboardLocationSubmit();
		}
		else
		{
			if (!HasFinishedLoading())
			{
				return;
			}
			if (playerEntry != null)
			{
				for (int i = 0; i < entries.Length; i++)
				{
					if (entries[i].playerId == playerEntry.playerId)
					{
						entries[i].isLocalPlayer = true;
						break;
					}
				}
			}
			SetLeaderboardScreenState(LeaderboardScreenState.Idle);
			UpdateContents();
		}
	}

	private void LeaderboardEventSubmitResponseDataCallback(LeaderboardEventSubmitResponseData data)
	{
		Utils.LogIfEditor("EventSubmit -> Callback");
		if (currentLeaderboardScreenState != LeaderboardScreenState.Loading || data == null)
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Retry);
			return;
		}
		playerEntry = data.entry;
		loadingSubmit = false;
		if (HasFinishedLoading())
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Idle);
			UpdateContents();
			return;
		}
		if (entries == null)
		{
			RequestLeaderboardLocationGet();
		}
		if (playerEntry == null && LeaderboardController.singleton.HasSubmitted())
		{
			RequestLeaderboardLocationPlayer();
		}
	}

	private void HandlePagePrev(DialogButton btn)
	{
		if (currentLeaderboardScreenState == LeaderboardScreenState.Idle)
		{
			currentPage--;
			if (currentPage < 0)
			{
				currentPage = 0;
			}
			RequestLeaderboardLocationGet();
		}
	}

	private void HandlePageNext(DialogButton btn)
	{
		if (currentLeaderboardScreenState == LeaderboardScreenState.Idle)
		{
			currentPage++;
			if (currentPage >= totalPages)
			{
				currentPage = totalPages - 1;
			}
			RequestLeaderboardLocationGet();
		}
	}

	private void HandleClosePressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleRetryOkPressed(DialogButton btn)
	{
		if (LeaderboardController.singleton.GetPlayerId() == null && LeaderboardController.singleton.CanSubmit(leaderboardId))
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Submit);
		}
		else
		{
			SetLeaderboardScreenState(LeaderboardScreenState.Loading);
			RequestLeaderboardLocationGet();
			if (LeaderboardController.singleton.GetPlayerId() != null)
			{
				RequestLeaderboardLocationPlayer();
			}
		}
		Utils.LogIfEditor("RetryOk");
	}

	private void HandleSubmitOkPressed(DialogButton btn)
	{
		AnalyticsMacros.LocationLeaderboardSubmitOk();
		RequestLeaderboardLocationSubmit();
		Utils.LogIfEditor("SubmitOk");
	}

	private void HandleSubmitCancelPressed(DialogButton btn)
	{
		AnalyticsMacros.LocationLeaderboardSubmitCancel();
		RequestLeaderboardLocationGet();
		Utils.LogIfEditor("SubmitCancel");
	}

	private void OnDestroy()
	{
		prevButton.OnPressed -= HandlePagePrev;
		nextButton.OnPressed -= HandlePageNext;
		closeButton.OnPressed -= HandleClosePressed;
	}

	private LocationLeaderboardRow InstantiateNewRow()
	{
		LocationLeaderboardRow locationLeaderboardRow = Object.Instantiate(defaultRow);
		locationLeaderboardRow.transform.parent = base.transform;
		return locationLeaderboardRow;
	}

	protected override void Awake()
	{
		base.Awake();
		prevButton.OnPressed += HandlePagePrev;
		nextButton.OnPressed += HandlePageNext;
		closeButton.OnPressed += HandleClosePressed;
		playerRow = InstantiateNewRow();
		while (rows.Count < entriesPerPage)
		{
			LocationLeaderboardRow locationLeaderboardRow = InstantiateNewRow();
			if (rows.Count % 2 == 0)
			{
				locationLeaderboardRow.SetBackgroundColor(ColorConstants.darkGrey);
			}
			else
			{
				locationLeaderboardRow.SetBackgroundColor(ColorConstants.darkGrey * 0.5f);
			}
			locationLeaderboardRow.Setup(startRank + rows.Count, null);
			rows.Add(locationLeaderboardRow);
		}
		retryDialog.okButton.OnPressed += HandleRetryOkPressed;
		retryDialog.okButton.keyCode = KeyCode.Return;
		retryDialog.cancelButton.keyCode = KeyCode.Escape;
		submitDialog.okButton.OnPressed += HandleSubmitOkPressed;
		submitDialog.cancelButton.OnPressed += HandleSubmitCancelPressed;
		submitDialog.okButton.keyCode = KeyCode.Return;
		submitDialog.cancelButton.keyCode = KeyCode.Escape;
	}

	public bool ShouldShowMoneyHUD()
	{
		return showMoneyHUD;
	}
}
