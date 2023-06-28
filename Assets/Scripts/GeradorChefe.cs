using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour {

	private float tempoParaProximaGeracao = 0;
	private float tempoEntreGeracoes = 40;
	public GameObject ChefePrefab;
	private ControlaInterface scriptControlaInterface;
	public Transform[] PosicoesPossiveisDeGeracao;
	private Transform Jogador;

	private void Start() {
		tempoParaProximaGeracao = tempoEntreGeracoes;
		scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
		Jogador = GameObject.FindWithTag("Jogador").transform;
	}

	private void Update() {
		if (Time.timeSinceLevelLoad > tempoParaProximaGeracao){
			Vector3 posicaoDeCriacao = CalcularPosicaoMaisDistanteDoJogador();
			Instantiate(ChefePrefab, posicaoDeCriacao, Quaternion.identity);
			scriptControlaInterface.AparecerTextoChefeCriado();
			tempoParaProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
		}
	}

	Vector3 CalcularPosicaoMaisDistanteDoJogador(){
		Vector3 posicaoDeMaiorDistancia = Vector3.zero;
		float maiorDistancia = 0;

		foreach(Transform posicao in PosicoesPossiveisDeGeracao){
			float distanciaEntreJogador = Vector3.Distance(posicao.position, Jogador.position);
			if (distanciaEntreJogador > maiorDistancia){
				maiorDistancia = distanciaEntreJogador;
				posicaoDeMaiorDistancia = posicao.position;
			}
		}

		return posicaoDeMaiorDistancia;
	}

}
