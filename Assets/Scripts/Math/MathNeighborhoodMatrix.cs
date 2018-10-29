﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathNeighborhoodMatrix {

	protected OList<MathVertex> vertexes;

	public MathNeighborhoodMatrix(){
		vertexes = new OList<MathVertex> ();
	}

	public void AddVertex(){
		
		for (int i = 0; i < vertexes.Count; i++) {
			vertexes.Get (i).AddPossibility ();
		}

		vertexes.Add (new MathVertex ());

		vertexes.Get (vertexes.Count - 1).AddPossibilities (vertexes.Count);
	}

	public void RemoveVertex(int _vertex){
		for (int i = 0; i < vertexes.Count; i++) {
			vertexes [i].RemoveAt (_vertex);
		}
			
		vertexes.RemoveAt (_vertex);
	}

	public void AddEdge(int x, int y){
		vertexes [x] [y] += 1;
		vertexes [y] [x] += 1;
	}

	public void RemoveEdge(int x, int y){
		vertexes [x] [y] -= 1;
		vertexes [y] [x] -= 1;
	}

	public string Print(){
		string output = "";
		output += " Macierz sąsiedztwa : \n";
		for (int i = 0; i < vertexes.Count; i++)
		{
			output += "\t" + i;
		}

		for (int i = 0; i < vertexes.Count; i++)
		{
			output += "\n";
			for (int j = 0; j < vertexes.Get(i).Count; j++)
			{
				if(j == 0)
				{
					output += i;
				}

				output += "\t" + vertexes[i][j];                  
			}
		}
		return output;
	}

	public void Construct(List<int> graph){
		for (int i = 0; i < graph.Count; i++)
		{
			AddVertex();
		}

		for (int i = 0; i < vertexes.Count; i++)
		{
			int degree = graph[0];
			var degreeOfVertex = vertexes [i].Value ();
			degree -= degreeOfVertex;
			for (int j = 1; j <= degree; j++)
			{
				for (int k = i+j; k < vertexes.Count; k++)
				{
					if (vertexes[i + j].Value() < graph[i + j])
					{
						AddEdge(i, i + j);
						break;
					}
				}
			}
		}
	}
}
