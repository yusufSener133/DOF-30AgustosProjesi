using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [Header("Assignment")]
    private GameObject _boxes;
    private Camera _camera;
    [Header("Values")]
    private Vector3 _startPos;
    private float _maxDistance = .5f;
    private bool _correctPos = false;
    private IEnumerator Start()
    {
        _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _boxes = PuzzleManager.Instance.Boxes;
        yield return new WaitForSeconds(.2f);
        _startPos = transform.position;
    }
    void Update()
    {
        ClickUp();
    }
    private void OnMouseDrag()
    {
        if (_correctPos)
            return;
        Vector3 worldPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        transform.position = worldPos;
    }
    void ClickUp()
    {
        if (Input.GetMouseButtonUp(0) && !_correctPos)
        {
            foreach (var box in _boxes.GetComponentsInChildren<Transform>())
            {
                if (box.name == transform.name)
                {
                    float distance = Vector3.Distance(box.position, transform.position);
                    Vector3 _endPos = _startPos;
                    if (distance < _maxDistance)
                    {
                        _correctPos = true;
                        _endPos = box.position;
                        PuzzleManager.Instance.AddCount();
                    }
                    transform.position = _endPos;
                }
            }
        }
    }
}/**/
