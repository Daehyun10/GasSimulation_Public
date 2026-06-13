# Screenshot Guide

보고서와 발표 자료에 넣을 이미지는 직접 Unity 실행 화면을 캡처해서 이 폴더에 넣으면 됩니다.

## 추천 파일명

```text
01_hierarchy.png
02_high_temperature.png
03_low_temperature_liquefaction.png
04_pressure_graph.png
```

## 사진 1. Unity Hierarchy

캡처할 내용:

- `ContainerWalls`
- `GasManager`
- `GasParticles`
- `Canvas`
- `Main Camera`

캡션 예시:

```text
그림 1. 시뮬레이션 장면의 Unity Hierarchy 구조
```

## 사진 2. 고온 조건

조건:

- Temperature Slider: 700~800 K
- 주황색 기체 분자가 활발히 움직이는 장면
- 액화 분자가 거의 없는 장면

캡션 예시:

```text
그림 2. 고온 조건에서 활발하게 운동하는 기체 분자
```

## 사진 3. 저온 액화 조건

조건:

- Temperature Slider: 100~150 K
- cyan 색 액화 분자가 바닥에 모이는 장면

캡션 예시:

```text
그림 3. 저온 조건에서 액화되어 바닥에 모인 분자
```

## 사진 4. CSV 그래프

Excel 또는 Google Sheets에서 CSV를 열고 다음 그래프를 만든다.

- x축: `time`
- y축: `p_ideal`, `p_real`
- 그래프 종류: 선그래프

캡션 예시:

```text
그림 4. 온도 변화에 따른 이상기체 압력과 실제 압력의 비교
```

