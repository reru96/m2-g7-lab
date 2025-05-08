using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Media;
using UnityEngine;

public class Rooms
{
    private TIPODISTANZA tipo;
    public Player player;
    //public Enemy enemy;
List<TIPODISTANZA> mappa = new List<TIPODISTANZA>();
    public void CreoStanza(string nome, int posizione)
    {
        TIPODISTANZA nuovastanza = new TIPODISTANZA(nome, posizione);
        mappa.Add(nuovastanza);
        AssegnoTipoStanza();
        Debug.log ( "è stata aggiunta una nuova stanza: " + nome + posizione);
        //ok;
    }

    private void AssegnoTipoStanza()
    {
        tipo =  (TIPODISTANZA)  Random.Range(0,4);

        switch (tipo)
        {
            case TIPODISTANZA.STANZANEMICO:

                Enemy enemy = CreoNemico();
                player.enemy = enemy;
                player.traps = null;

                TIPODINEMICO tiponemico = enemy.tipo;

                Debug.Log("Hai trovato un " + tiponemico);
                player.Combattimento();
                player.GetMovimento();
                break;

            case TIPODISTANZA.STANZATRAPPOLA:

                Traps traps = CreoTrappola();
                player.traps = traps;
                Debug.Log("hai trovato una trappola");
                player.GetMovimento();
                player.enemy = null;
                break;


            case TIPODISTANZA.STANZAVUOTA:

                Debug.Log("hai trovato una stanza vuota");
                player.GetMovimento();
                player.enemy = null;
                player.traps = null;

                break;


            case TIPODISTANZA.STANZATESORO:

                Debug.Log("hai trovato un tesoro");
                player.GetMovimento();
                player.enemy = null;
                player.traps = null;

                break;

            default:
                break;
        }
    }

    private Enemy CreoNemico()
    {

        Enemy enemy = new Enemy();

        //Debug.Log(" Creo un nuovo nemico...");

        enemy.SetEnemy();

        Debug.Log(" Nuovo nemico: " + enemy.tipo + " con " + enemy.vita + " HP");

        return enemy;
    }

    private Traps CreoTrappola()
    {
        Traps traps = new Traps();

        //Debug.Log("Creo una nuova trappola");

        traps.SetTrap();

        //Debug.Log("Nuova trappola; ");

        return traps;
    }

}
