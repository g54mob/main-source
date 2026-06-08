using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Mono.Data.Sqlite;
using UnityEngine;

public class UniversityLevel : Level
{
	public enum SuspectClass
	{
		Economics = 0,
		Philosophy = 1,
		Science = 2
	}

	public class Syllabus
	{
		public List<SeatingAssignment> seating;

		public List<Attendance> attendance;

		public List<ExamScore> scores;

		public Syllabus()
		{
			seating = new List<SeatingAssignment>();
			attendance = new List<Attendance>();
			scores = new List<ExamScore>();
		}

		public void LoadSeating(string[] row)
		{
			seating.Add(SeatingAssignment.BuildFromRow(row));
		}

		public void LoadAttendance(string[] row)
		{
			attendance.Add(Attendance.BuildFromRow(row));
		}

		public void LoadScores(string[] row)
		{
			scores.Add(ExamScore.BuildFromRow(row));
		}
	}

	protected static ICollection<string> everyone = new HashSet<string>();

	public const int LEVEL_NUMBER = 7;

	public static SuspectClass SUSPECT_CLASS;

	public static SuspectClass CLOSE_CLASS;

	private const int SEATS_PER_ROW = 40;

	private const int SUSPECT_SCORE = 12;

	private const int TEXTING_PARTNER_SCORE = 76;

	private static List<Student> students;

	private static Syllabus economics;

	private static Syllabus science;

	private static Syllabus philosophy;

	private static Person culprit;

	public static bool LoadWebsiteDownloads(IDbConnection connection)
	{
		SUSPECT_CLASS = Save.GetSuspectClass();
		CLOSE_CLASS = Save.GetSuspectCloseClass();
		if (CreateTablesHelpers.LoadSavedTable(connection, teachersonly_data.TABLE_NAME, LoadStudents) && LoadSyllabus(connection, SuspectClass.Economics, economics) && LoadSyllabus(connection, SuspectClass.Science, science))
		{
			return LoadSyllabus(connection, SuspectClass.Philosophy, philosophy);
		}
		return false;
		static void LoadStudents(string[] row)
		{
			students.Add(Student.BuildFromRow(row));
		}
	}

	public static bool LoadSyllabus(IDbConnection connection, SuspectClass classType, Syllabus syllabus)
	{
		if (CreateTablesHelpers.LoadSavedTable(connection, lzu_syllabus.GetSeatsTableName(classType), syllabus.LoadSeating) && CreateTablesHelpers.LoadSavedTable(connection, lzu_syllabus.GetAttendanceTableName(classType), syllabus.LoadAttendance))
		{
			return CreateTablesHelpers.LoadSavedTable(connection, lzu_syllabus.GetScoresTableName(classType), syllabus.LoadScores);
		}
		return false;
	}

	public static void PrintContents()
	{
		Debug.Log($"students count -> {students.Count}");
		PrintSyllabus(SuspectClass.Economics, economics);
		PrintSyllabus(SuspectClass.Science, science);
		PrintSyllabus(SuspectClass.Philosophy, philosophy);
		static void PrintSyllabus(SuspectClass c, Syllabus s)
		{
			Debug.Log($"{c} seats count -> {s.seating.Count}");
			Debug.Log($"{c} attendance count -> {s.attendance.Count}");
			Debug.Log($"{c} scores count -> {s.scores.Count}");
		}
	}

	public static void SaveDownloads()
	{
		SqliteConnection connection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE);
		DatabaseUtils.Begin(connection);
		CreateStudentsTable(connection, commit: false);
		SaveSyllabus(connection, SuspectClass.Economics);
		SaveSyllabus(connection, SuspectClass.Science);
		SaveSyllabus(connection, SuspectClass.Philosophy);
		DatabaseUtils.Commit(connection);
		((IDbConnection)connection).Close();
		static void SaveSyllabus(IDbConnection connection2, SuspectClass suspectClass)
		{
			CreateSeatingTable(suspectClass, connection2, commit: false);
			CreateAttendanceTable(suspectClass, connection2, commit: false);
			CreateExamTable(suspectClass, connection2, commit: false);
		}
	}

	public static void Create(bool hasLoad)
	{
		InitVariables();
		using (IDbConnection dbConnection = DatabaseUtils.GetConnection(Save.SAVES_DATABASE))
		{
			if (Level.Load(dbConnection, everyone, hasLoad) && LoadWebsiteDownloads(dbConnection))
			{
				PrintContents();
				return;
			}
		}
		DatabaseUtils.DropAllTables();
		ChooseClass();
		LoadSyllabuses();
		LoadPhilosophyTable();
		LoadScienceTable();
		LoadEconomicsTable();
		Debug.Log($"Finished loading Level {7}.");
		SaveDownloads();
		Level.SaveData(culprit.firstName, culprit.lastName, everyone);
		PrintContents();
	}

	private static List<SuspectClass> GetPossibleClasses()
	{
		return new List<SuspectClass>
		{
			SuspectClass.Economics,
			SuspectClass.Philosophy,
			SuspectClass.Science
		};
	}

	private static void InitVariables()
	{
		students = new List<Student>();
		economics = new Syllabus();
		science = new Syllabus();
		philosophy = new Syllabus();
	}

	private static void ChooseClass()
	{
		List<SuspectClass> possibleClasses = GetPossibleClasses();
		SUSPECT_CLASS = CreateTablesHelpers.GetRandomValue(possibleClasses);
		possibleClasses.Remove(SUSPECT_CLASS);
		CLOSE_CLASS = CreateTablesHelpers.GetRandomValue(possibleClasses);
		Debug.Log($"suspect in class : {SUSPECT_CLASS}");
		Debug.Log($"class with close answer : {CLOSE_CLASS}");
		Save.SaveUniClass((int)SUSPECT_CLASS, (int)CLOSE_CLASS);
	}

	private static Syllabus GetClassSyllabus(SuspectClass lzuClass)
	{
		return lzuClass switch
		{
			SuspectClass.Economics => economics, 
			SuspectClass.Philosophy => philosophy, 
			SuspectClass.Science => science, 
			_ => throw new InvalidOperationException(), 
		};
	}

	public static string GetClassString(SuspectClass lzuClass)
	{
		return lzuClass switch
		{
			SuspectClass.Economics => "econ", 
			SuspectClass.Philosophy => "phil", 
			SuspectClass.Science => "sci", 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static (string[], int) GetClassSchedule(SuspectClass lzuClass)
	{
		switch (lzuClass)
		{
		case SuspectClass.Economics:
			return (new string[2] { "T", "Th" }, 16);
		case SuspectClass.Philosophy:
		case SuspectClass.Science:
			return (new string[3] { "M", "W", "Th" }, 25);
		default:
			throw new InvalidOperationException();
		}
	}

	private static Dictionary<string, string[]> ClassCalendar()
	{
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		dictionary["M"] = new string[9] { "05/04/98", "05/11/98", "05/18/98", "05/25/98", "06/01/98", "06/08/98", "06/15/98", "06/22/98", "06/29/98" };
		dictionary["T"] = new string[9] { "05/05/98", "05/12/98", "05/19/98", "05/26/98", "06/02/98", "06/09/98", "06/16/98", "06/23/98", "06/30/98" };
		dictionary["W"] = new string[8] { "05/06/98", "05/13/98", "05/20/98", "05/27/98", "06/03/98", "06/10/98", "06/17/98", "06/24/98" };
		dictionary["Th"] = new string[8] { "05/07/98", "05/14/98", "05/21/98", "05/28/98", "06/04/98", "06/11/98", "06/18/98", "06/25/98" };
		dictionary["F"] = new string[8] { "05/08/98", "05/15/98", "05/22/98", "05/29/98", "06/05/98", "06/12/98", "06/19/98", "06/26/98" };
		return dictionary;
	}

	private static void LoadSyllabuses()
	{
		HashSet<int> ids = new HashSet<int>();
		AddArtStudents();
		char[] rows = new char[11]
		{
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
			'K'
		};
		Dictionary<char, List<int>> avaliableSeats = InitializeAvailableSeats();
		Dictionary<string, string[]> classDays = ClassCalendar();
		Syllabus suspectSyllabus = GetClassSyllabus(SUSPECT_CLASS);
		List<SuspectClass> possibleClasses = GetPossibleClasses();
		possibleClasses.Remove(SUSPECT_CLASS);
		Student suspect = GetSuspect();
		Student partner = CreateTextingPartner();
		PopulateSyllabus(SUSPECT_CLASS);
		foreach (SuspectClass item3 in possibleClasses)
		{
			avaliableSeats = InitializeAvailableSeats();
			PopulateSyllabus(item3);
		}
		for (int i = 0; i < 1200; i++)
		{
			string studentId = CreateTablesHelpers.GetUniqueId(ids).ToString();
			var (firstName, lastName) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, suspect.firstName, suspect.lastName, everyone);
			students.Add(new Student(firstName, lastName, studentId));
		}
		foreach (SuspectClass possibleClass in GetPossibleClasses())
		{
			Syllabus classSyllabus = GetClassSyllabus(possibleClass);
			classSyllabus.attendance = classSyllabus.attendance.OrderBy((Attendance m) => m.date).ToList();
			classSyllabus.seating = (from m in classSyllabus.seating
				orderby m.row, m.column
				select m).ToList();
			classSyllabus.scores = classSyllabus.scores.OrderBy((ExamScore m) => CreateTablesHelpers.RANDY.Next()).ToList();
		}
		students = students.OrderBy((Student m) => CreateTablesHelpers.RANDY.Next()).ToList();
		void AddArtStudent(string first, string last)
		{
			CreateTablesHelpers.AddName(everyone, (first, last));
			string studentId2 = CreateTablesHelpers.GetUniqueId(ids).ToString();
			students.Add(new Student(first, last, studentId2));
		}
		void AddArtStudents()
		{
			AddArtStudent("Mark", "Rockthrow");
			AddArtStudent("Jackson", "Cod");
			AddArtStudent("Patricia", "Marie");
			AddArtStudent("Frances", "Joy");
			AddArtStudent("Peter", "Mondy");
			AddArtStudent("Martha", "Lisa");
			AddArtStudent("Andrew", "Basil");
		}
		void AddAttendance(SuspectClass currClass, List<Attendance> attendance, string studentId2, int percentAttendance)
		{
			(string[], int) classSchedule = GetClassSchedule(currClass);
			string[] item = classSchedule.Item1;
			int item2 = classSchedule.Item2;
			List<int> list = Enumerable.Range(0, item2).ToList();
			int num = (int)((double)percentAttendance / 100.0 * (double)item2);
			for (int j = 0; j < num; j++)
			{
				int randomValue = CreateTablesHelpers.GetRandomValue(list);
				list.Remove(randomValue);
				string date = GetClassDay(item, randomValue);
				attendance.Add(new Attendance(studentId2, date));
			}
		}
		void AddStudent(Syllabus syllabus, int scoreMin, int scoreMax, int attendMin, int attendMax)
		{
			var (row, col) = GenerateSeatAssignment();
			AddStudentWithRow(syllabus, scoreMin, scoreMax, attendMin, attendMax, row, col);
		}
		void AddStudentWithNeighbors(Syllabus syllabus, int students, int neighborScoreMin)
		{
			for (int j = 0; j < students; j++)
			{
				var (row, col) = GenerateSeatAssignment();
				AddStudentWithRow(syllabus, 10, 20, 15, 40, row, col);
				foreach (var (row2, col2) in GetSeatAssignmentNeighbors(row, col))
				{
					AddStudentWithRow(syllabus, neighborScoreMin, 85, 50, 80, row2, col2);
				}
			}
		}
		void AddStudentWithRow(Syllabus syllabus, int scoreMin, int scoreMax, int attendMin, int attendMax, char row, int col)
		{
			string studentId2 = CreateTablesHelpers.GetUniqueId(ids).ToString();
			var (firstName2, lastName2) = CreateTablesHelpers.GetName(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames, suspect.firstName, suspect.lastName, everyone);
			students.Add(new Student(firstName2, lastName2, studentId2));
			int score = CreateTablesHelpers.RANDY.Next(scoreMin, scoreMax);
			syllabus.scores.Add(new ExamScore(studentId2, score));
			syllabus.seating.Add(new SeatingAssignment(studentId2, row, col));
			AddAttendance(SUSPECT_CLASS, syllabus.attendance, studentId2, CreateTablesHelpers.RANDY.Next(attendMin, attendMax));
		}
		void AddStudents(Syllabus syllabus, int studentAmount, int scoreMin, int scoreMax, int attendMin, int attendMax)
		{
			for (int j = 0; j < studentAmount; j++)
			{
				AddStudent(syllabus, scoreMin, scoreMax, attendMin, attendMax);
			}
		}
		Student CreateTextingPartner()
		{
			string studentId2 = CreateTablesHelpers.GetUniqueId(ids).ToString();
			string text = "Matthew";
			string text2 = "Hoji";
			Student student = new Student(text, text2, studentId2);
			students.Add(student);
			CreateTablesHelpers.AddName(everyone, (text, text2));
			return student;
		}
		(char, int) GenerateSeatAssignment()
		{
			if (avaliableSeats.Count <= 0)
			{
				throw new ArgumentException($"Too many seats attempted to be inserted. Limit is {rows.Length * 40} seats");
			}
			KeyValuePair<char, List<int>> randomValue = CreateTablesHelpers.GetRandomValue(avaliableSeats);
			int randomValue2 = CreateTablesHelpers.GetRandomValue(randomValue.Value);
			RemoveSeatPossibility(randomValue.Value, randomValue.Key, randomValue2);
			return (randomValue.Key, randomValue2);
		}
		string GetClassDay(string[] schedule, int day)
		{
			string key = schedule[day % schedule.Length];
			return classDays[key][day / schedule.Length];
		}
		List<(char, int)> GetSeatAssignmentNeighbors(char row, int col)
		{
			if (avaliableSeats.Count <= 0)
			{
				throw new ArgumentException($"Too many seats attempted to be inserted. Limit is {rows.Length * 40} seats");
			}
			List<(char, int)> neighbors = new List<(char, int)>();
			AddNeighbor(col + 1);
			AddNeighbor(col - 1);
			return neighbors;
			void AddNeighbor(int neighborCol)
			{
				if (avaliableSeats.ContainsKey(row) && avaliableSeats[row].Contains(neighborCol))
				{
					neighbors.Add((row, neighborCol));
					RemoveSeatPossibility(avaliableSeats[row], row, neighborCol);
				}
			}
		}
		Student GetSuspect()
		{
			string id = CreateTablesHelpers.GetUniqueId(ids).ToString();
			Student student = GenerateSuspect();
			students.Add(student);
			var (c, num) = GenerateSeatAssignment();
			suspectSyllabus.scores.Add(new ExamScore(id, 12));
			suspectSyllabus.seating.Add(new SeatingAssignment(student.studentId, c, num));
			AddAttendance(SUSPECT_CLASS, suspectSyllabus.attendance, id, 25);
			SetSuspectNeighbor(student, c, num);
			return student;
			Student GenerateSuspect()
			{
				(string, string) tuple3 = CreateTablesHelpers.GetCulprit(CreateTablesHelpers.firstNames, CreateTablesHelpers.lastNames);
				string item = tuple3.Item1;
				string item2 = tuple3.Item2;
				culprit = new Person(item, item2);
				return new Student(item, item2, id);
			}
		}
		Dictionary<char, List<int>> InitializeAvailableSeats()
		{
			Dictionary<char, List<int>> dictionary = new Dictionary<char, List<int>>();
			char[] array = rows;
			foreach (char key in array)
			{
				dictionary[key] = Enumerable.Range(1, 40).ToList();
			}
			return dictionary;
		}
		void PopulateSyllabus(SuspectClass currClass)
		{
			Syllabus classSyllabus2 = GetClassSyllabus(currClass);
			SetTextingPartner(currClass, partner);
			AddStudentWithNeighbors(classSyllabus2, 15, 25);
			AddStudentWithNeighbors(classSyllabus2, 5, 76);
			AddStudents(classSyllabus2, 30, 25, 70, 15, 50);
			AddStudents(classSyllabus2, 5, 10, 12, 60, 100);
			AddStudents(classSyllabus2, rows.Length * 40 - classSyllabus2.seating.Count - CreateTablesHelpers.RANDY.Next(10, 20), 12, 101, 60, 101);
		}
		void RemoveSeatPossibility(List<int> cols, char row, int col)
		{
			cols.Remove(col);
			if (cols.Count == 0)
			{
				avaliableSeats.Remove(row);
			}
		}
		void SetSuspectNeighbor(Student student, char suspectRow, int suspectColumn)
		{
			int num = suspectColumn switch
			{
				1 => suspectColumn + 1, 
				40 => suspectColumn - 1, 
				_ => suspectColumn + (CreateTablesHelpers.RANDY.Next(2) * -2 + 1), 
			};
			string studentId2 = CreateTablesHelpers.GetUniqueId(ids).ToString();
			int score = CreateTablesHelpers.RANDY.Next(90, 101);
			var (firstName2, lastName2) = CreateTablesHelpers.GetName(CreateTablesHelpers.femNames, CreateTablesHelpers.lastNames, student.firstName, student.lastName, everyone);
			students.Add(new Student(firstName2, lastName2, studentId2));
			suspectSyllabus.scores.Add(new ExamScore(studentId2, score));
			suspectSyllabus.seating.Add(new SeatingAssignment(studentId2, suspectRow, num));
			RemoveSeatPossibility(avaliableSeats[suspectRow], suspectRow, num);
			AddAttendance(SUSPECT_CLASS, suspectSyllabus.attendance, studentId2, 100);
		}
		void SetTextingPartner(SuspectClass lzuClass, Student student)
		{
			Syllabus classSyllabus2 = GetClassSyllabus(lzuClass);
			(char, int) tuple2 = GenerateSeatAssignment();
			char item = tuple2.Item1;
			int item2 = tuple2.Item2;
			int score = ((lzuClass == SUSPECT_CLASS) ? 76 : CreateTablesHelpers.RANDY.Next(70, 90));
			classSyllabus2.scores.Add(new ExamScore(student.studentId, score));
			classSyllabus2.seating.Add(new SeatingAssignment(student.studentId, item, item2));
			AddAttendance(lzuClass, classSyllabus2.attendance, student.studentId, CreateTablesHelpers.RANDY.Next(80, 90));
		}
	}

	public static void CreateSeatingTable(SuspectClass lzuClass, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string tableName = GetClassString(lzuClass) + "_seats";
		string text = "student_id";
		string text2 = "row";
		string text3 = "seat_number";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " INT, PRIMARY KEY(" + text2 + ", " + text3 + ")");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, GetClassSyllabus(lzuClass).seating, commit);
	}

	public static void CreateAttendanceTable(SuspectClass lzuClass, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string tableName = GetClassString(lzuClass) + "_attendance";
		string text = "student_id";
		string text2 = "attend_date";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, PRIMARY KEY(" + text + ", " + text2 + ")");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { text, text2 }, GetClassSyllabus(lzuClass).attendance, commit);
	}

	public static void CreateExamTable(SuspectClass lzuClass, IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string tableName = GetClassString(lzuClass) + "_scores";
		string text = "student_id";
		string text2 = "score";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " INT, PRIMARY KEY(" + text + ")");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { text, text2 }, GetClassSyllabus(lzuClass).scores, commit);
	}

	public static void CreateStudentsTable(IDbConnection connection = null, bool commit = true)
	{
		if (connection == null)
		{
			connection = DatabaseUtils.GetConnection();
		}
		string tableName = "students";
		string text = "student_id";
		string text2 = "first_name";
		string text3 = "last_name";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " TEXT, PRIMARY KEY(" + text + ")");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, students, commit);
	}

	private static List<Export> LoadEconomicsTable()
	{
		List<string[]> list = ResourcesManager.GetCSV("Names/economics").ToList();
		List<Export> list2 = new List<Export>();
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i];
			list2.Add(new Export(array[0], array[1], int.Parse(array[2]), int.Parse(array[3])));
		}
		return list2;
	}

	public static void CreateEconomicsTable()
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string tableName = GetClassString(SuspectClass.Economics) + "_hwk";
		string text = "export";
		string text2 = "category";
		string text3 = "year";
		string text4 = "export_worth";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " TEXT, " + text3 + " INT, " + text4 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[4] { text, text2, text3, text4 }, LoadEconomicsTable());
	}

	private static List<GlassesIndoors> LoadScienceTable()
	{
		List<string[]> list = ResourcesManager.GetCSV("Names/science").ToList();
		List<GlassesIndoors> list2 = new List<GlassesIndoors>();
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i];
			list2.Add(new GlassesIndoors(array[0], int.Parse(array[1]), int.Parse(array[2])));
		}
		return list2;
	}

	public static void CreateScienceTable()
	{
		IDbConnection connection = DatabaseUtils.GetConnection();
		string tableName = GetClassString(SuspectClass.Science) + "_hwk";
		string text = "cool_person";
		string text2 = "age";
		string text3 = "brosephs_said";
		DatabaseUtils.CreateTable(connection, tableName, text + " TEXT, " + text2 + " INT, " + text3 + " INT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[3] { text, text2, text3 }, LoadScienceTable());
	}

	private static List<Influence> LoadPhilosophyTable()
	{
		List<Influence> list = new List<Influence>();
		List<string[]> list2 = ResourcesManager.GetCSV("Names/philosophy").ToList();
		for (int i = 0; i < list2.Count; i++)
		{
			string[] array = list2[i];
			list.Add(new Influence(array[0], array[1].Trim('\r', '\n')));
		}
		return list.OrderBy((Influence m) => m.philosopher).ToList();
	}

	public static void CreatePhilosophyTable()
	{
		SqliteConnection connection = DatabaseUtils.GetConnection();
		string tableName = GetClassString(SuspectClass.Philosophy) + "_hwk";
		DatabaseUtils.CreateTable(connection, tableName, "philosopher TEXT, directly_influenced TEXT");
		CreateTablesHelpers.PopulateTable(connection, tableName, new string[2] { "philosopher", "directly_influenced" }, LoadPhilosophyTable());
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}
