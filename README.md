# Ideal Gas vs Real Gas Liquefaction Simulation

고등학교 화학 II 탐구 발표용으로 제작한 Unity 3D 기반 기체 분자 운동 시뮬레이션 프로젝트 설명 저장소입니다.

> 공개용 저장소이므로 핵심 Unity C# 구현 코드는 포함하지 않았습니다.  
> 보고서, 실험 구조, 그래프 작성 방법, CSV 형식, 이미지 삽입 안내만 제공합니다.

## 탐구 주제

Unity 3D 기체 분자 운동 시뮬레이션을 통해 이상기체 상태방정식 `PV=nRT`와 실제 기체의 저온 액화 현상을 비교한다.

## 핵심 개념

이 탐구는 다음 세 가지 관계를 중심으로 구성됩니다.

```text
v(T) = v0 * sqrt(T / T0)
```

온도가 변하면 기체 분자의 대표 속도가 `sqrt(T)`에 비례하도록 설정했습니다.

```text
P_ideal = nRT / V
```

이상기체 압력은 이상기체 상태방정식으로 계산했습니다.

```text
P_real ≈ ΣJ / (AΔt)
```

실제 압력은 분자가 벽에 충돌할 때의 충격량 `J`를 누적한 뒤, 용기 표면적 `A`와 측정 시간 `Δt`로 나누어 근사했습니다.

## 함수는 어떤 형태가 좋은가?

보고서와 발표에서는 복잡한 함수보다 아래처럼 **독립 변인과 종속 변인이 분명한 형태**가 좋습니다.

| 목적 | 추천 함수 형태 | 의미 |
|---|---|---|
| 온도와 속도 관계 | `v(T)=v0√(T/T0)` | 온도가 높을수록 분자 속도 증가 |
| 이상기체 압력 | `P_ideal(T,V)=nRT/V` | 온도 증가 시 압력 증가, 부피 증가 시 압력 감소 |
| 실제 압력 근사 | `P_real≈ΣJ/(AΔt)` | 벽 충돌 충격량으로 실제 압력 근사 |
| 오차율 | `Error=|P_ideal-P_real|/P_ideal×100` | 이상기체와 실제 기체의 차이 |

그래프는 함수식 자체보다 **CSV 데이터를 이용한 선그래프**

추천 그래프:

1. `time`에 따른 `P_ideal`, `P_real` 비교
2. `time`에 따른 `error_percent`
3. `time`에 따른 `liquid_count`

## 저장소 구성

```text
.
├─ README.md
├─ docs/
│  └─ report_public.md
├─ data/
│  └─ sample_csv_template.csv
└─ assets/
   └─ screenshots/
      └─ README.md
```

## 실험 데이터 CSV 형식

```csv
time,temperature,volume,p_ideal,p_real,error_percent,liquid_count
```

각 항목의 의미:

| 항목 | 의미 |
|---|---|
| `time` | 실험 경과 시간 |
| `temperature` | 현재 온도 |
| `volume` | 용기 부피 |
| `p_ideal` | 이상기체식으로 계산한 압력 |
| `p_real` | 벽 충돌 충격량으로 근사한 실제 압력 |
| `error_percent` | 두 압력의 오차율 |
| `liquid_count` | 액화된 분자 수 |


## 공개 범위

이 저장소에는 다음을 포함하지 않습니다.

- Unity 전체 프로젝트
- 핵심 C# 스크립트
- 개인 PC 경로
- Unity Library/Temp/Logs 캐시


