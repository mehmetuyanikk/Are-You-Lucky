using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _score, _enYuksekSkor;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _EnYuksekScoreText;
    [SerializeField] Button _button;
    [SerializeField] GameObject _kayit;

    int a = 7;

    private void Start()
    {
        _enYuksekSkor = PlayerPrefs.GetInt("skor");

        _EnYuksekScoreText.text = "En Yüksek Skor: " + _enYuksekSkor.ToString();
    }

    private void Update()
    {
        Bitir();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("dost"))
        {
            int _geciciSkor = Random.Range(10, 101);

            _score += _geciciSkor;
            _scoreText.text = _score.ToString();

            Destroy(collision.gameObject);
            a--;

            EnYuksekSkorHesapla();
        }

        if (collision.gameObject.CompareTag("dusman"))
        {
            int _geciciskor2 = Random.Range(0, 2);

            EnYuksekSkorHesapla();

            if (_geciciskor2 == 0)
            {
                SkorFisekle();
                Destroy(collision.gameObject);
                a--;

                EnYuksekSkorHesapla();
            }

            else if (_geciciskor2 == 1)
            {
                SkorSifirla();
                Destroy(collision.gameObject);
                a--;

                EnYuksekSkorHesapla();
            }

        }
    }

    void SkorFisekle()
    {
        int _geciciskor = Random.Range(100, 201);
        _score = _score * _geciciskor;
        _scoreText.text = _score.ToString();
    }

    void SkorSifirla()
    {
        _score = _score * 0;
        _scoreText.text = _score.ToString();

    }

    void EnYuksekSkorHesapla()
    {

        if (_score > _enYuksekSkor)
        {
            PlayerPrefs.SetInt("skor", _score);
        }

    }

    void Bitir()
    {

        if (a == 0)
        {
            Time.timeScale = 0;
            _kayit.SetActive(true);
        }

    }

    public void Baslat()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        a = 7;
        _kayit.SetActive(false);
    }

}
