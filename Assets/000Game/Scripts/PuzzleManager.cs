using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    #region Singleton
    private static PuzzleManager _instance;
    public static PuzzleManager Instance { get => _instance; }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [SerializeField] private Transform[] _puzzlesSpawnPos;
    [SerializeField] private Transform _puzzleParent;
    [SerializeField] private GameObject _EndingCanvas;
    [SerializeField] private GameObject _puzzles;
    [SerializeField] private GameObject _boxes;
    public GameObject Boxes { get => _boxes; }
    private List<int> _nums = new List<int>();
    private float _count = 0f;

    private void Start()
    {
        CreatePuzzle();
    }
    void Update()
    {
        if (_puzzlesSpawnPos.Length == _count)
            NextScene();
    }
    public void AddCount() => _count++;
    void CreatePuzzle()
    {
        for (int i = 0; i < _puzzles.GetComponentsInChildren<SpriteRenderer>().Length; i++) 
            _nums.Add(i);
        foreach (var item in _puzzlesSpawnPos)
        {
            int spawnObjectName = NewNumber();
            GameObject go = _puzzles.GetComponentsInChildren<SpriteRenderer>()[spawnObjectName].gameObject;
            go.transform.position = item.position;
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<PuzzleController>();
            go.name = spawnObjectName.ToString();
        }
    }
    int NewNumber()
    {
        int num = _nums[Random.Range(0, _nums.Count)];
        _nums.Remove(num);
        return num;
    }
    void NextScene()
    {
        _EndingCanvas.SetActive(true);
    }
}/**/
