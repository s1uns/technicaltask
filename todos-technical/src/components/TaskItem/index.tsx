import styled from "@emotion/styled";
import { Checkbox } from "@mui/material";
import { TodoItem } from "../../types/TodoItem";
import { checkTask } from "../../api/tasks";
import { useState } from "react";

interface TaskItemProps {
	id: string;
	isCompleted: boolean;
	text: string;
	setItems: React.Dispatch<React.SetStateAction<TodoItem[]>>;
}

export default function TaskItem({
	id,
	isCompleted,
	text,
	setItems,
}: TaskItemProps) {
	const [disabled, setDisabled] = useState(false);
	const handleCheckItem = async () => {
		setDisabled(true);
		const newItem: TodoItem = await checkTask(id);
		setDisabled(false);
		setItems((prev) =>
			prev.map((item) =>
				item.id === id
					? { ...item, isCompleted: newItem.isCompleted }
					: item,
			),
		);
	};
	return (
		<ItemContainer>
			<ItemCheckbox
				checked={isCompleted}
				onClick={handleCheckItem}
				disabled={disabled}
			/>
			<ItemText checked={isCompleted}>{text}</ItemText>
		</ItemContainer>
	);
}

const ItemContainer = styled.div`
	width: 90%;
	padding: 0 30px;
	height: 30px;
	display: flex;
	flex-direction: row;
	align-items: center;
	justify-content: flex-start;
`;

const ItemCheckbox = styled(Checkbox)``;

const ItemText = styled.p<{ checked: boolean }>`
	color: ${({ checked }) => (checked ? "gray" : "black")};
`;
