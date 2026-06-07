using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNNNet : MonoBehaviour
{
	public class RNNLayer
	{
		private int cou;

		public MultiplyGate mulGate = new MultiplyGate();

		public AddGate addGate = new AddGate();

		public Tanh activation = new Tanh();

		private List<double> mulu = new List<double>();

		private List<double> mulw = new List<double>();

		private List<double> add = new List<double>();

		public List<double> s = new List<double>();

		public List<double> mulv = new List<double>();

		private void PrintMatrix(string label, List<List<double>> matrix)
		{
			Debug.Log(label);
			foreach (List<double> item in matrix)
			{
				string text = "[";
				foreach (double item2 in item)
				{
					text = text + item2 + " ";
				}
				text += "]";
				Debug.Log(text);
			}
		}

		public void forward(List<double> x, List<double> prev_s, List<List<double>> U, List<List<double>> W, List<List<double>> V)
		{
			mulu = mulGate.forward(U, x);
			mulw = mulGate.forward(W, prev_s);
			add = addGate.forward(mulw, mulu);
			s = activation.forward(add);
			PrintListInf("s", s);
			mulv = mulGate.forward(V, s);
			cou++;
		}

		private void PrintList(string label, List<double> list)
		{
			Debug.Log(label);
			string text = "";
			foreach (double item in list)
			{
				text = text + item + " ";
			}
			Debug.Log(text);
		}

		private void PrintListInf(string label, List<double> list)
		{
			bool flag = false;
			foreach (double item in list)
			{
				if (double.IsInfinity(item))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			Debug.Log(label);
			string text = "";
			foreach (double item2 in list)
			{
				text = text + item2 + " ";
			}
			Debug.Log(text);
			int num = 0;
			_ = 1 / num;
		}

		public List<List<List<double>>> backward(List<double> x, List<double> prev_s, List<List<double>> U, List<List<double>> W, List<List<double>> V, List<double> diff_s, List<double> dmulv)
		{
			List<List<List<double>>> list = new List<List<List<double>>>();
			forward(x, prev_s, U, W, V);
			KeyValuePair<List<List<double>>, List<double>> keyValuePair = mulGate.backward(V, s, dmulv);
			List<List<double>> key = keyValuePair.Key;
			List<double> value = keyValuePair.Value;
			List<double> top_diff = addGate.forward(value, diff_s);
			List<List<double>> dz = activation.backward(add, top_diff);
			List<List<double>> list2 = addGate.backward(mulw, mulu, dz);
			List<double> dz2 = list2[0];
			List<double> dz3 = list2[1];
			keyValuePair = mulGate.backward(W, prev_s, dz2);
			List<List<double>> key2 = keyValuePair.Key;
			List<double> value2 = keyValuePair.Value;
			keyValuePair = mulGate.backward(U, x, dz3);
			List<List<double>> key3 = keyValuePair.Key;
			_ = keyValuePair.Value;
			list.Add(new List<List<double>> { value2 });
			list.Add(key3);
			list.Add(key2);
			list.Add(key);
			return list;
		}
	}

	public class MultiplyGate
	{
		public List<double> dot(List<List<double>> a, List<double> b)
		{
			List<double> list = new List<double>();
			for (int i = 0; i < a.Count; i++)
			{
				double num = 0.0;
				for (int j = 0; j < b.Count; j++)
				{
					num += a[i][j] * b[j];
					if (double.IsNaN(num))
					{
						Debug.Log(num + " " + a[i][j] + " " + b[j]);
						int num2 = 0;
						_ = 1 / num2;
					}
				}
				list.Add(num);
			}
			return list;
		}

		public List<List<double>> dotTwoWec(List<double> a, List<double> b)
		{
			List<List<double>> list = new List<List<double>>();
			string text = "+";
			foreach (double item in b)
			{
				text = text + item + " ";
			}
			for (int i = 0; i < a.Count; i++)
			{
				List<double> list2 = new List<double>();
				for (int j = 0; j < b.Count; j++)
				{
					list2.Add(a[i] * b[j]);
				}
				list.Add(list2);
			}
			return list;
		}

		public List<List<double>> transponse(List<List<double>> a)
		{
			List<List<double>> list = new List<List<double>>();
			for (int i = 0; i < a[0].Count; i++)
			{
				List<double> list2 = new List<double>();
				for (int j = 0; j < a.Count; j++)
				{
					list2.Add(a[j][i]);
				}
				list.Add(list2);
			}
			return list;
		}

		public List<double> forward(List<List<double>> W, List<double> x)
		{
			return dot(W, x);
		}

		public KeyValuePair<List<List<double>>, List<double>> backward(List<List<double>> W, List<double> x, List<double> dz)
		{
			List<List<double>> key = dotTwoWec(dz, x);
			List<double> value = dot(transponse(W), dz);
			return new KeyValuePair<List<List<double>>, List<double>>(key, value);
		}
	}

	public class AddGate
	{
		public List<double> forward(List<double> a, List<double> b)
		{
			List<double> list = new List<double>();
			for (int i = 0; i < a.Count; i++)
			{
				list.Add(a[i] + b[i]);
			}
			return list;
		}

		public List<double> dot(List<List<double>> a, List<double> b)
		{
			List<double> list = new List<double>();
			for (int i = 0; i < a.Count; i++)
			{
				double num = 0.0;
				for (int j = 0; j < b.Count; j++)
				{
					num += a[i][j] * b[j];
				}
				list.Add(num);
			}
			return list;
		}

		public List<List<double>> backward(List<double> x1, List<double> x2, List<List<double>> dz)
		{
			List<List<double>> list = new List<List<double>>();
			List<double> list2 = new List<double>();
			List<double> list3 = new List<double>();
			for (int i = 0; i < x1.Count; i++)
			{
				list2.Add(1.0);
			}
			for (int j = 0; j < x2.Count; j++)
			{
				list3.Add(1.0);
			}
			list.Add(dot(dz, list2));
			list.Add(dot(dz, list3));
			return list;
		}
	}

	public class Tanh
	{
		public List<List<double>> dotTwoWec(List<double> a, List<double> b)
		{
			List<List<double>> list = new List<List<double>>();
			string text = "?";
			foreach (double item in b)
			{
				text = text + item + " ";
			}
			for (int i = 0; i < a.Count; i++)
			{
				List<double> list2 = new List<double>();
				for (int j = 0; j < b.Count; j++)
				{
					list2.Add(a[i] * b[j]);
				}
				list.Add(list2);
			}
			return list;
		}

		public List<double> forward(List<double> x)
		{
			List<double> list = new List<double>();
			for (int i = 0; i < x.Count; i++)
			{
				list.Add(Math.Tan(x[i]));
			}
			return list;
		}

		public List<List<double>> backward(List<double> x, List<double> top_diff)
		{
			List<double> list = forward(x);
			for (int i = 0; i < x.Count; i++)
			{
				list[i] = 1.0 - list[i] * list[i];
			}
			return dotTwoWec(list, top_diff);
		}
	}

	public class SoftMax
	{
		private void PrintList(string label, List<double> list)
		{
			Debug.Log(label);
			string text = "";
			foreach (double item in list)
			{
				text = text + item + " ";
			}
			Debug.Log(text);
		}

		public List<double> predict(List<double> x)
		{
			List<double> list = new List<double>();
			List<double> list2 = new List<double>();
			double num = 0.0;
			double num2 = -1.0;
			for (int i = 0; i < x.Count; i++)
			{
				list2.Add(x[i]);
				num2 = Math.Max(x[i], num2);
			}
			for (int j = 0; j < x.Count; j++)
			{
				list2[j] -= num2;
			}
			foreach (double item in list2)
			{
				if (double.IsInfinity(item))
				{
					int num3 = 0;
					_ = 1 / num3;
				}
				list.Add(Math.Exp(item));
				if (double.IsInfinity(list[list.Count - 1]))
				{
					Debug.Log(item + " " + Math.Exp(item));
					int num4 = 0;
					_ = 1 / num4;
				}
				num += Math.Exp(item);
			}
			for (int k = 0; k < list.Count; k++)
			{
				list[k] /= num;
				if (double.IsNaN(list[k]))
				{
					int num5 = 0;
					_ = 1 / num5;
				}
			}
			return list;
		}

		public double loss(List<double> x, int y)
		{
			double num = 0.0 - Math.Log(predict(x)[y]);
			if (double.IsNaN(num))
			{
				num = 0.0;
			}
			return num;
		}

		public List<double> diff(List<double> x, int y)
		{
			List<double> list = predict(x);
			list[y] -= 1.0;
			return list;
		}
	}

	public class Model
	{
		private int word_dim;

		private int hidden_dim;

		private int bptt_truncate;

		private List<List<double>> U = new List<List<double>>();

		private List<List<double>> W = new List<List<double>>();

		private List<List<double>> V = new List<List<double>>();

		private int T;

		private double lastLoss = -1.0;

		public double GetRandomNumber(double minimum, double maximum)
		{
			return new System.Random().NextDouble() * (maximum - minimum) + minimum;
		}

		public Model(int word_dim, int hidden_dim, int bptt_truncate)
		{
			this.word_dim = word_dim;
			this.hidden_dim = hidden_dim;
			this.bptt_truncate = bptt_truncate;
			for (int i = 0; i < hidden_dim; i++)
			{
				List<double> list = new List<double>();
				for (int j = 0; j < word_dim; j++)
				{
					list.Add(UnityEngine.Random.Range(0f - Mathf.Sqrt(1f / (float)word_dim), Mathf.Sqrt(1f / (float)word_dim)));
				}
				U.Add(list);
			}
			for (int k = 0; k < hidden_dim; k++)
			{
				List<double> list2 = new List<double>();
				for (int l = 0; l < hidden_dim; l++)
				{
					list2.Add(UnityEngine.Random.Range(0f - Mathf.Sqrt(1f / (float)word_dim), Mathf.Sqrt(1f / (float)word_dim)));
				}
				W.Add(list2);
			}
			for (int m = 0; m < word_dim; m++)
			{
				List<double> list3 = new List<double>();
				for (int n = 0; n < hidden_dim; n++)
				{
					list3.Add(UnityEngine.Random.Range(0f - Mathf.Sqrt(1f / (float)word_dim), Mathf.Sqrt(1f / (float)word_dim)));
				}
				V.Add(list3);
			}
		}

		public List<RNNLayer> forward_propagation(List<int> x)
		{
			T = x.Count;
			List<RNNLayer> list = new List<RNNLayer>();
			List<double> list2 = new List<double>();
			for (int i = 0; i < hidden_dim; i++)
			{
				list2.Add(0.0);
			}
			for (int j = 0; j < T; j++)
			{
				RNNLayer rNNLayer = new RNNLayer();
				List<double> list3 = new List<double>();
				for (int k = 0; k < word_dim; k++)
				{
					list3.Add(0.0);
				}
				list3[x[j]] = 1.0;
				rNNLayer.forward(list3, list2, U, W, V);
				list2 = rNNLayer.s;
				list.Add(rNNLayer);
			}
			return list;
		}

		public List<int> predict(List<int> x)
		{
			List<int> list = new List<int>();
			SoftMax softMax = new SoftMax();
			List<RNNLayer> list2 = forward_propagation(x);
			for (int i = 0; i < list2.Count; i++)
			{
				int item = 0;
				double num = 0.0;
				List<double> list3 = softMax.predict(list2[i].mulv);
				string text = "";
				for (int j = 0; j < list3.Count; j++)
				{
					text = text + list3[j] + " ";
					if (list3[j] > num)
					{
						num = list3[j];
						item = j;
					}
				}
				list.Add(item);
			}
			return list;
		}

		public double calculate_loss(List<int> x, List<int> y)
		{
			double num = 0.0;
			SoftMax softMax = new SoftMax();
			List<RNNLayer> list = forward_propagation(x);
			for (int i = 0; i < list.Count; i++)
			{
				foreach (double item in list[i].mulv)
				{
					if (item > 100.0)
					{
						return -1000.0;
					}
				}
				num += softMax.loss(list[i].mulv, y[i]);
			}
			if (double.IsInfinity(num))
			{
				num = 10000.0;
			}
			return num / (double)y.Count;
		}

		public double calculate_total_loss(List<List<int>> x, List<List<int>> y)
		{
			double num = 0.0;
			for (int i = 0; i < x.Count; i++)
			{
				double num2 = calculate_loss(x[i], y[i]);
				if (num2 < 0.0)
				{
					num = -100.0;
					break;
				}
				num += num2;
			}
			return num / (double)y.Count;
		}

		private void PrintList(string label, List<double> list)
		{
			Debug.Log(label);
			string text = "";
			foreach (double item in list)
			{
				text = text + item + " ";
			}
			Debug.Log(text);
		}

		private void PrintList(string label, List<int> list)
		{
			Debug.Log(label);
			string text = "";
			foreach (int item in list)
			{
				text = text + item + " ";
			}
			Debug.Log(text);
		}

		private List<List<List<double>>> bptt(List<int> x, List<int> y)
		{
			List<List<List<double>>> list = new List<List<List<double>>>();
			SoftMax softMax = new SoftMax();
			List<RNNLayer> list2 = forward_propagation(x);
			List<List<double>> list3 = new List<List<double>>();
			List<List<double>> list4 = new List<List<double>>();
			List<List<double>> list5 = new List<List<double>>();
			for (int i = 0; i < U.Count; i++)
			{
				List<double> list6 = new List<double>();
				for (int j = 0; j < U[0].Count; j++)
				{
					list6.Add(0.0);
				}
				list3.Add(list6);
			}
			for (int k = 0; k < W.Count; k++)
			{
				List<double> list7 = new List<double>();
				for (int l = 0; l < W[0].Count; l++)
				{
					list7.Add(0.0);
				}
				list4.Add(list7);
			}
			for (int m = 0; m < V.Count; m++)
			{
				List<double> list8 = new List<double>();
				for (int n = 0; n < V[0].Count; n++)
				{
					list8.Add(0.0);
				}
				list5.Add(list8);
			}
			int count = list2.Count;
			List<double> list9 = new List<double>();
			List<double> list10 = new List<double>();
			for (int num = 0; num < hidden_dim; num++)
			{
				list9.Add(0.0);
				list10.Add(0.0);
			}
			for (int num2 = 0; num2 < count; num2++)
			{
				List<double> dmulv = softMax.diff(list2[num2].mulv, y[num2]);
				List<double> list11 = new List<double>();
				for (int num3 = 0; num3 < word_dim; num3++)
				{
					list11.Add(0.0);
				}
				list11[x[num2]] = 1.0;
				List<List<List<double>>> list12 = list2[num2].backward(list11, list9, U, W, V, list10, dmulv);
				_ = list12[0][0];
				List<List<double>> list13 = list12[1];
				List<List<double>> list14 = list12[2];
				List<List<double>> b = list12[3];
				list9 = list2[num2].s;
				dmulv = new List<double>();
				for (int num4 = 0; num4 < word_dim; num4++)
				{
					dmulv.Add(0.0);
				}
				for (int num5 = num2 - 1; num5 > Mathf.Max(-1, num2 - bptt_truncate - 1); num5--)
				{
					list11 = new List<double>();
					for (int num6 = 0; num6 < word_dim; num6++)
					{
						list11.Add(0.0);
					}
					list11[x[num5]] = 1.0;
					if (num5 == 0)
					{
						List<double> list15 = new List<double>();
						for (int num7 = 0; num7 < hidden_dim; num7++)
						{
							list15.Add(0.0);
						}
					}
					else
					{
						List<double> list15 = list2[num5 - 1].s;
					}
					List<List<List<double>>> list16 = list2[num2].backward(list11, list9, U, W, V, list10, dmulv);
					_ = list16[0][0];
					List<List<double>> b2 = list16[1];
					List<List<double>> b3 = list16[2];
					list13 = SumMatrix(list13, b2, 1.0);
					list14 = SumMatrix(list14, b3, 1.0);
				}
				list3 = SumMatrix(list3, list13, 1.0);
				list4 = SumMatrix(list4, list14, 1.0);
				list5 = SumMatrix(list5, b, 1.0);
			}
			list.Add(list3);
			list.Add(list4);
			list.Add(list5);
			return list;
		}

		public void AddMatrix(ref List<List<double>> a, List<List<double>> b, double val)
		{
			for (int i = 0; i < a.Count; i++)
			{
				for (int j = 0; j < a[0].Count; j++)
				{
					a[i][j] += b[i][j] * val;
				}
			}
		}

		public List<List<double>> SumMatrix(List<List<double>> a, List<List<double>> b, double val)
		{
			List<List<double>> list = new List<List<double>>();
			for (int i = 0; i < a.Count; i++)
			{
				List<double> list2 = new List<double>();
				for (int j = 0; j < a[0].Count; j++)
				{
					list2.Add(a[i][j] + b[i][j] * val);
				}
				list.Add(list2);
			}
			return list;
		}

		public void sgd_step(List<int> x, List<int> y, double learning_rate)
		{
			List<List<List<double>>> list = bptt(x, y);
			U = SumMatrix(U, list[0], 0.0 - learning_rate);
			W = SumMatrix(W, list[1], 0.0 - learning_rate);
			V = SumMatrix(V, list[2], 0.0 - learning_rate);
		}

		private void PrintMatrix(string label, List<List<double>> matrix)
		{
			Debug.Log(label);
			foreach (List<double> item in matrix)
			{
				string text = "[";
				foreach (double item2 in item)
				{
					text = text + item2 + " ";
				}
				text += "]";
				Debug.Log(text);
			}
		}

		public List<KeyValuePair<int, double>> train(List<List<int>> x, List<List<int>> y, double learning_rate, int nepoch, int eval_loss_after)
		{
			int num = 0;
			List<KeyValuePair<int, double>> list = new List<KeyValuePair<int, double>>();
			for (int i = 0; i < nepoch; i++)
			{
				if (i % eval_loss_after == 0)
				{
					double num2 = calculate_total_loss(x, y);
					list.Add(new KeyValuePair<int, double>(num, num2));
					Debug.Log("Loss " + num2);
					if (Math.Abs(lastLoss - num2) < 0.01)
					{
						learning_rate *= 2.0;
					}
					else if (list.Count > 1 && list[list.Count - 1].Value > list[list.Count - 2].Value)
					{
						learning_rate *= 0.5;
					}
				}
				for (int j = 0; j < y.Count; j++)
				{
					sgd_step(x[j], y[j], learning_rate);
					num++;
				}
				PrintMatrix("U", U);
			}
			return list;
		}

		public IEnumerator trainIter(List<List<int>> x, List<List<int>> y, double learning_rate, int nepoch, int eval_loss_after)
		{
			int num_seen_ex = 0;
			List<KeyValuePair<int, double>> losses = new List<KeyValuePair<int, double>>();
			for (int epoch = 0; epoch < nepoch; epoch++)
			{
				_ = learning_rate;
				_ = 0.001;
				if (epoch % eval_loss_after == 0)
				{
					double num = calculate_total_loss(x, y);
					if (num < 0.0)
					{
						break;
					}
					losses.Add(new KeyValuePair<int, double>(num_seen_ex, num));
					Debug.Log("Loss " + num);
					if (Math.Abs(lastLoss - num) < 0.01)
					{
						learning_rate *= 1.2;
					}
					else if (losses.Count > 1 && losses[losses.Count - 1].Value > losses[losses.Count - 2].Value)
					{
						learning_rate *= 0.5;
						Debug.Log("New learning rate " + learning_rate);
					}
					lastLoss = num;
				}
				for (int i = 0; i < y.Count; i++)
				{
					sgd_step(x[i], y[i], learning_rate);
					num_seen_ex++;
				}
				yield return new WaitForEndOfFrame();
			}
			PrintPredict("hello");
		}

		private void PrintPredict(string inp)
		{
			List<int> list = new List<int>();
			foreach (char c in inp)
			{
				if (c == ' ')
				{
					list.Add(27);
				}
				else
				{
					list.Add(c - 97);
				}
			}
			List<int> list2 = predict(list);
			string text = "";
			foreach (int item in list2)
			{
				text = ((item != 27) ? (text + (char)(item + 97)) : (text + " "));
			}
			Debug.Log(text);
		}
	}

	private Model m;

	private int IntFromChat(char c)
	{
		if (c == ' ')
		{
			return 27;
		}
		return c - 97;
	}

	private void Start()
	{
		Debug.Log(Math.Exp(100.0));
		List<List<int>> list = new List<List<int>>();
		List<List<int>> list2 = new List<List<int>>();
		Resources.Load("text1");
		string text = "hello";
		text = text.ToLower();
		int length = text.Length;
		for (int i = 0; i < 1; i++)
		{
			List<int> list3 = new List<int>();
			List<int> list4 = new List<int>();
			for (int j = 0; j < length - 1; j++)
			{
				list3.Add(IntFromChat(text[i + j]));
				list4.Add(IntFromChat(text[i + j + 1]));
			}
			list.Add(list3);
			list2.Add(list4);
		}
		int num = 28;
		m = new Model(num, num, 4);
		StartCoroutine(m.trainIter(list, list2, 0.005, 2000, 1));
	}

	private void Update()
	{
	}
}
