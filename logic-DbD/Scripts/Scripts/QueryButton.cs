using System;
using System.Collections;
using System.Data;
using CielaSpike;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QueryButton : MonoBehaviour
{
	public const float TRANSACTION_TIMEOUT_LIMIT = 5f;

	public const int MAX_ICON_AMOUNT = 40;

	public static bool USE_CUSTOM_PARSER = true;

	[SerializeField]
	private CreatePanels panelConstructor;

	[SerializeField]
	private IconGenerator iconConstructor;

	[SerializeField]
	private TMP_InputField queryInput;

	[SerializeField]
	private NotificationHandler errorHandler;

	[SerializeField]
	private Toggle saveToggle;

	[SerializeField]
	private TMP_InputField tableNameInput;

	[SerializeField]
	private Button queryButton;

	[SerializeField]
	private CoroutineRunner assistantSpawner;

	[SerializeField]
	private EmergencyMessagePopup emergencyMessagePopup;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private QueryHistoryManager queryHistoryManager;

	[SerializeField]
	private TaskbarManager taskbarManager;

	[SerializeField]
	private Sprite tableSprite;

	private bool transactionCompleted;

	private GameObject notification;

	private GameObject recentResult;

	private string recentResultName;

	private Notification sfxPlayer;

	private bool hasQueryChanged;

	private void Start()
	{
		sfxPlayer = SoundEffectUtils.GetNotificationPlayer();
		GetComponent<PlayerInput>().actions["Enter Query"].performed += delegate
		{
			if (ShouldOpenRecent())
			{
				PanelManager.OpenWindow(recentResult);
				GetComponent<AudioSource>().Play();
				taskbarManager.AddTaskbar(recentResult, tableSprite, recentResultName);
			}
			else if (hasQueryChanged && queryButton.interactable)
			{
				QueryButtonPressed();
			}
		};
		TMP_InputField tMP_InputField = tableNameInput;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => IconGenerator.ValidateTableName(addedChar)));
		queryHistoryManager.LoadQueries();
	}

	private bool ShouldOpenRecent()
	{
		if (!hasQueryChanged && recentResult != null)
		{
			return !taskbarManager.IsMaximumTaskbarButtons(recentResult);
		}
		return false;
	}

	public void QueryButtonPressed()
	{
		SetQueryHints();
		if (ShouldOpenRecent())
		{
			PanelManager.OpenWindow(recentResult);
			GetComponent<AudioSource>().Play();
			taskbarManager.AddTaskbar(recentResult, tableSprite, recentResultName);
			return;
		}
		hasQueryChanged = false;
		UIUtils.LogCollection("All Tables -> ", DatabaseUtils.GetAllTableNames());
		int childCount = iconConstructor.transform.childCount;
		if (saveToggle.isOn && iconConstructor.transform.childCount > 40)
		{
			int num = childCount - 40;
			string arg = ((num == 1) ? "icon" : "icons");
			QueryError($"There are too many tables. Please delete {num} {arg}.");
			return;
		}
		string text = ((saveToggle.isOn && tableNameInput.text.Length > 0) ? tableNameInput.text : TableNameGenerator.GetName());
		if (!IconGenerator.IsTableNameValid(errorHandler, text))
		{
			Debug.Log("Invalid table name: " + text);
			return;
		}
		string text2 = queryInput.text.Replace('\n', ' ');
		var (flag, text3) = QueryParser.HasForbiddenKeywords(text2);
		if (flag)
		{
			QueryError("Illegal word detected! The word " + text3 + " cannot be used in your query.");
			emergencyMessagePopup.InstantiatePopupMessage(MessageSpawner.MessageCodes.IllegalKeyword, 2f);
		}
		else if ((!USE_CUSTOM_PARSER || !RunCustomParser(text2)) && !taskbarManager.IsMaximumTaskbarButtons())
		{
			SetLevelHints();
			string query = QueryParser.SelectIntoQueryConvertor(text2, text);
			IDbConnection connection = DatabaseUtils.GetConnection();
			transactionCompleted = false;
			DatabaseUtils.Begin(connection);
			this.StartCoroutineAsync(ExecuteQuery(connection, query), out var task);
			StartCoroutine(WaitForQuery(connection, text, task, text2));
		}
	}

	private void SetLevelHints()
	{
		if (LevelManager.GetCurrLevel() == 5 && queryInput.text.Contains(Level5.GetSuspectIP()))
		{
			HintManager.SetHintState(5, 3);
		}
	}

	private void SetQueryHints()
	{
		switch (LevelManager.GetCurrLevel())
		{
		case 4:
			if (HintManager.GetQueryState() == 3)
			{
				HintManager.SetQueryState(4);
			}
			return;
		case 8:
			return;
		}
		if (HintManager.GetQueryState() == 2)
		{
			HintManager.SetQueryState(3);
		}
		else if (HintManager.GetQueryState() == 0)
		{
			HintManager.SetQueryState(1);
		}
	}

	private bool RunCustomParser(string queryString)
	{
		bool result = false;
		IDbConnection connection = DatabaseUtils.GetConnection();
		Parser parser = new Parser(queryString, connection);
		try
		{
			parser.ParseQuery();
		}
		catch (Parser.ParserException ex)
		{
			result = true;
			QueryError(ex.Message);
		}
		catch (Parser.UnsupportedException)
		{
		}
		catch (Parser.WarningException)
		{
		}
		catch (Exception)
		{
		}
		connection.Close();
		return result;
	}

	private void FindWarning(string queryString)
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		Parser parser = new Parser(queryString, connection);
		try
		{
			parser.ParseQuery();
		}
		catch (Parser.ParserException)
		{
		}
		catch (Parser.UnsupportedException)
		{
		}
		catch (Parser.WarningException ex3)
		{
			ClearNotification();
			notification = errorHandler.CreateNotificationPanel("Warning", NotificationHandler.Icon.WARNING, ex3.Message);
			PanelManager.OpenWindow(notification);
		}
		catch (Exception)
		{
		}
		connection.Close();
	}

	public IEnumerator WaitForQuery(IDbConnection connection, string tableName, Task queryExecution, string originalQuery)
	{
		float timer = 0f;
		while (timer < 5f)
		{
			timer += Time.deltaTime;
			if (queryExecution.State == TaskState.Error)
			{
				Exception exception = queryExecution.Exception;
				if (exception is SqliteException)
				{
					QueryError(exception.Message);
				}
				yield break;
			}
			if (transactionCompleted)
			{
				break;
			}
			yield return null;
		}
		if (iconConstructor.transform.childCount >= 40)
		{
			string errorMessage = "There are too many icons on your desktop. Please clean up your icons before adding more tables.";
			DatabaseUtils.DropTable(tableName);
			QueryError(errorMessage);
			yield break;
		}
		if (!transactionCompleted)
		{
			string errorMessage2 = "Search results timed out. Try to limit results in the WHERE or FROM clause.";
			RollbackQuerySubmission(connection, queryExecution, errorMessage2);
		}
		Debug.Log("Transaction took " + timer + " seconds.");
		try
		{
			GameObject window = panelConstructor.CreateUserPanel(tableName, saveToggle.isOn);
			if (saveToggle.isOn)
			{
				ThomasGridLayoutGroup.AddIcon(iconConstructor.CreateIcon(tableName).transform);
				tableNameInput.text = "";
				Save.SetSearchTip();
			}
			else if (!CreateTables.DEV_MODE && LevelManager.GetCurrLevel() > 0 && !Save.GetSearchTip())
			{
				Save.SetSearchTip();
				assistantSpawner.StartCoroutine(assistant.PlaySearchTutorialDialogue);
			}
			recentResult = window;
			recentResultName = tableName;
			FindWarning(originalQuery);
			GetComponent<AudioSource>().Play();
			queryHistoryManager.AddQueryHistory(queryInput.text);
			PanelManager.OpenWindow(window);
			taskbarManager.AddTaskbar(window, tableSprite, tableName);
		}
		catch (IllegalQueryException ex)
		{
			QueryError(ex.Message);
			DatabaseUtils.DropTable(tableName);
		}
		catch (EmptyResultException ex2)
		{
			ClearNotification();
			string toolbar = "No Results Found";
			notification = errorHandler.CreateNotificationPanel(toolbar, NotificationHandler.Icon.EMPTY_RESULTS, ex2.Message);
			PanelManager.OpenWindow(notification);
			queryHistoryManager.AddQueryHistory(queryInput.text);
			DatabaseUtils.DropTable(tableName);
		}
	}

	public IEnumerator ExecuteQuery(IDbConnection connection, string query)
	{
		try
		{
			IDbCommand dbCommand = connection.CreateCommand();
			Debug.Log("Executing query: " + query);
			dbCommand.CommandText = query;
			dbCommand.ExecuteNonQuery();
		}
		catch (SqliteException ex)
		{
			throw ex;
		}
		DatabaseUtils.Commit(connection);
		transactionCompleted = true;
		yield break;
	}

	public void ToggleNameTable()
	{
		sfxPlayer.PlayToggle(saveToggle.isOn);
		tableNameInput.gameObject.SetActive(saveToggle.isOn);
	}

	public void ToggleButton()
	{
		hasQueryChanged = true;
		if (recentResult != null)
		{
			recentResult = null;
			recentResultName = "";
		}
		queryButton.interactable = queryInput.text.Trim().Length > 0;
	}

	private void RollbackQuerySubmission(IDbConnection connection, Task queryExecution, string errorMessage)
	{
		DatabaseUtils.Rollback(connection);
		queryExecution.Cancel();
		QueryError(errorMessage);
	}

	private void ClearNotification()
	{
		if (notification != null)
		{
			UnityEngine.Object.Destroy(notification);
		}
	}

	private void QueryError(string errorMessage)
	{
		ClearNotification();
		notification = errorHandler.CreateNotificationPanel(errorMessage);
		PanelManager.OpenWindow(notification);
	}
}
